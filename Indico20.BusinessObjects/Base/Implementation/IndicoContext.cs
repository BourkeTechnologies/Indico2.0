using Dapper;
using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Common;
using Indico20.BusinessObjects.Objects.Core;
using Indico20.BusinessObjects.Procedures.Implementation;
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
        private readonly List<IEntity> _dirtyEntities;
        private readonly HashSet<IEntity> _deletedEntities;
        private readonly HashSet<IEntity> _addedEntities;
        private readonly IDbConnection _connection;
        private readonly HashSet<IEntity> _releasedEntities;

        public IndicoContext()
        {
            _connection = new SqlConnection(Indico20Configuration.AppSettings.ConnectionString);
            _connection.Open();
            _dirtyEntities = new List<IEntity>();
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

            var entity = _connection.Query<T>(QueryBuilder.Select(typeof(T).Name, id)).FirstOrDefault();
            if (entity == null)
                return null;
            _releasedEntities.Add(entity);
            entity.PropertyChanged += EntityPropertyChanged;
            entity._Context = this;
            return entity;
        }

        public IEnumerable<T> Get<T>() where T : class, IEntity
        {
            var entities = _connection.Query<T>(QueryBuilder.SelectAll(typeof(T).Name)).ToList();
            if (entities.Count <= 0)
                return entities;
            foreach (var entity in entities)
            {
                _releasedEntities.Add(entity);
                entity.PropertyChanged += EntityPropertyChanged;
                entity._Context = this;
            }
            return entities;
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
            {
                _addedEntities.Add(entity);
            }
        }

        private void EntityPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_dirtyEntities.Contains(sender))
                _dirtyEntities.Remove((IEntity)sender);
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
            if (_addedEntities.Count > 0)
            {
                foreach (var entity in _addedEntities.Where(entity => !_deletedEntities.Contains(entity)))
                {
                    builder.AppendLine(QueryBuilder.Insert(entity.GetType().Name, entity.GetColumnValueMapping()));
                }
                _connection.Execute(builder.ToString());
                builder.Clear();
                _addedEntities.Clear();
            }

            if (_deletedEntities.Count > 0)
            {
                foreach (var entity in _deletedEntities)
                {
                    builder.AppendLine(QueryBuilder.DeleteFromTable(entity.GetType().Name, entity.ID));
                }

                _connection.Execute(builder.ToString());
                builder.Clear();
                _deletedEntities.Clear();
            }

            if (_dirtyEntities.Count > 0)
            {
                foreach (var entity in _dirtyEntities.Where(entity => !_deletedEntities.Contains(entity)))
                {
                    builder.AppendLine(QueryBuilder.Update(entity.GetType().Name, entity.GetColumnValueMapping(), entity.ID));
                }
                _connection.Execute(builder.ToString());
                builder.Clear();
                _dirtyEntities.Clear();
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

        public IEnumerable<GetMenuItemsForUserRoleResult> GetMenuItemsForUserRole(int userRole)
        {
            return _connection.Query<GetMenuItemsForUserRoleResult>(QueryBuilder.ExecuteStoredProcedure("SPC_GetMenuItemsForUserRole", userRole));
        }
    }
}
