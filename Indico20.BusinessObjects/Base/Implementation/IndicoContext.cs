using Dapper;
using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Common;
using Indico20.BusinessObjects.Objects.Core;
using Indico20.BusinessObjects.Objects.Procedures.Core;
using Indico20CodeBase.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Indico20.BusinessObjects.Base.Implementation
{
    public class IndicoContext : IDbContext
    {
        private readonly HashSet<IEntity> _dirtyEntities;
        private readonly HashSet<IEntity> _deletedEntities;
        private readonly HashSet<IEntity> _addedEntities;
        private readonly IDbConnection _connection;
        private readonly HashSet<IEntity> _releasedEntities;

        public IndicoContext()
        {
            _connection = new SqlConnection(Indico20Configuration.AppSettings.ConnectionString);
            _connection.Open();
            _dirtyEntities = new HashSet<IEntity>();
            _deletedEntities = new HashSet<IEntity>();
            _addedEntities = new HashSet<IEntity>();
            _releasedEntities = new HashSet<IEntity>();
        }

        public T Get<T>(int id) where T : class, IEntity
        {
            if (_releasedEntities.Count > 0)
            {
                var ent = _releasedEntities.OfType<T>().Where(e => e.ID == id).ToList();
                if (ent.Count > 0)
                    return ent.FirstOrDefault();
            }

            T entity;
            try
            {
                entity = _connection.Query<T>(QueryBuilder.Select(typeof(T).Name, id)).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("cannot retrieve data from the database", e);
            }
            if (entity == null)
                return null;
            entity.PropertyChanged += EntityPropertyChanged;
            entity._Context = this;
            _releasedEntities.Add(entity);
            return entity;
        }

        public IEnumerable<T> Get<T>() where T : class, IEntity
        {
            List<T> entities;
            try
            {
                entities = _connection.Query<T>(QueryBuilder.SelectAll(typeof(T).Name)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("cannot retrieve data from the database", e);
            }
            if (entities.Count <= 0)
                return entities;
            foreach (var entity in entities)
            {
                entity.PropertyChanged += EntityPropertyChanged;
                entity._Context = this;
                _releasedEntities.Add(entity);
            }
            return entities;
        }

        public IEnumerable<T> GetFromStoredProcedure<T>(params object[] parameters) where T : class, ISpResult
        {
            try
            {
                return _connection.Query<T>(QueryBuilder.ExecuteStoredProcedure(typeof(T).Name, parameters));
            }
            catch (Exception e)
            {
                throw new Exception("Cannot retrieve data from the database.", e);
            }
        }

        public void Add(IEntity entity)
        {
            if (entity == null)
                return;
            _addedEntities.Add(entity);
        }

        public void AddRange(IEnumerable<IEntity> entities)
        {
            foreach (var entity in entities.Where(entity => entity != null))
                _addedEntities.Add(entity);
        }

        private void EntityPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _dirtyEntities.Add((IEntity)sender);
        }


        public void Dispose()
        {
            _connection.Close();
            _dirtyEntities.Clear();
            _addedEntities.Clear();
            _deletedEntities.Clear();
            foreach (var entity in _releasedEntities)
                entity.PropertyChanged -= EntityPropertyChanged;
            _releasedEntities.Clear();
        }

        public void SaveChanges()
        {
            var builder = new StringBuilder();
            var added = _addedEntities.Where(entity => !_deletedEntities.Contains(entity)).ToList();
            _addedEntities.Clear();
            if (added.Count > 0)
            {
                foreach (var entity in added)
                    builder.AppendLine(QueryBuilder.Insert(entity.GetType().Name, entity.GetColumnValueMapping()));
                try
                {
                    _connection.Execute(builder.ToString());
                }
                catch (Exception e)
                {
                    throw new Exception("Unable to add new items to the database", e);
                }

                builder.Clear();
            }

            var dirty = _dirtyEntities.Where(entity => !_deletedEntities.Contains(entity)).ToList();
            _dirtyEntities.Clear();
            if (dirty.Count > 0)
            {
                foreach (var entity in dirty)
                    builder.AppendLine(QueryBuilder.Update(entity.GetType().Name, entity.GetColumnValueMapping(), entity.ID));
                try
                {
                    _connection.Execute(builder.ToString());
                }
                catch (Exception e)
                {
                    throw new Exception("Unable to save changes in the database", e);
                }
                builder.Clear();
            }

            if (_deletedEntities.Count > 0)
            {
                foreach (var entity in _deletedEntities)
                    builder.AppendLine(QueryBuilder.DeleteFromTable(entity.GetType().Name, entity.ID));
                try
                {
                    _connection.Execute(builder.ToString());
                }
                catch (Exception e)
                {
                    throw new Exception("Unable to delete items from the database", e);
                }
                builder.Clear();
                _deletedEntities.Clear();
            }
        }

        public void Delete(IEntity entity)
        {
            if (entity != null && entity.ID > 0)
                _deletedEntities.Add(entity);
        }

        public void DeleteRange(IEnumerable<IEntity> entities)
        {
            var list = entities.ToList();
            if (entities == null || !list.Any())
                return;
            foreach (var entity in list)
                Delete(entity);
        }

        IEnumerable<T> IDbContext.Find<T>(Func<T, bool> predicate)
        {
            return Get<T>().Where(predicate);
        }

        IEnumerable<T> IDbContext.Where<T>(IDictionary<string, object> values)
        {
            var result = _connection.Query<T>(QueryBuilder.Where(typeof(T).Name, values)).ToList();
            if (result.Count <= 0)
                return result;
            foreach (var item in result)
            {
                _releasedEntities.Add(item);
                item.PropertyChanged += EntityPropertyChanged;
                item._Context = this;
            }
            return result;
        }
    }
}
