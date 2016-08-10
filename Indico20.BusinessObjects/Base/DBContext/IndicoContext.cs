﻿using Dapper;
using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Common;
using Indico20.BusinessObjects.Procedures;
using Indico20CodeBase.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Indico20.BusinessObjects.Base.DBContext
{
    public class IndicoContext : IDbContext
    {
        private readonly List<IEntity> _dirtyEntities;
        private readonly HashSet<IEntity> _deletedEntities;
        private readonly HashSet<IEntity> _addedEntities;

        private readonly IDbConnection _connection;


        public IndicoContext()
        {
            _connection = new SqlConnection(Indico20Configuration.AppSettings.ConnectionString);
            _connection.Open();
            _dirtyEntities = new List<IEntity>();
            _deletedEntities = new HashSet<IEntity>();
            _addedEntities = new HashSet<IEntity>();
        }

        public T Get<T>(string tableName, int id) where T : class, IEntity
        {
            var entity = _connection.Query<T>(QueryBuilder.Select(tableName, id)).FirstOrDefault();
            if (entity == null)
                return null;
            entity.PropertyChanged += EntityPropertyChanged;
            return entity;
        }

        public IEnumerable<T> Get<T>(string tableName) where T : class, IEntity
        {
            var entities = _connection.Query<T>(QueryBuilder.SelectAll(tableName)).ToList();
            if (entities.Count <= 0)
                return entities;
            foreach (var entity in entities)
                entity.PropertyChanged += EntityPropertyChanged;
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
        }

        public void SaveChanges()
        {
            var builder = new StringBuilder();
            if (_addedEntities.Count > 0)
            {
                foreach (var entity in _addedEntities.Where(entity => !_deletedEntities.Contains(entity)))
                {
                    builder.AppendLine(QueryBuilder.Insert(entity.TableName, entity.GetColumnValueMapping()));
                }
                _connection.Execute(builder.ToString());
                builder.Clear();
                _addedEntities.Clear();
            }

            if (_deletedEntities.Count > 0)
            {
                foreach (var entity in _deletedEntities)
                {
                    builder.AppendLine(QueryBuilder.DeleteFromTable(entity.TableName, entity.ID));
                }

                _connection.Execute(builder.ToString());
                builder.Clear();
                _deletedEntities.Clear();
            }

            if (_dirtyEntities.Count > 0)
            {
                foreach (var entity in _dirtyEntities.Where(entity => !_deletedEntities.Contains(entity)))
                {
                    builder.AppendLine(QueryBuilder.Update(entity.TableName, entity.GetColumnValueMapping(), entity.ID));
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

        IEnumerable<T> IDbContext.Find<T>(string tableName, Func<T, bool> predicate)
        {
            return Get<T>(tableName).Where(predicate);
        }

        public IEnumerable<GetMenuItemsForUserRoleResult> GetMenuItemsForUserRole(int userRole)
        {
            return _connection.Query<GetMenuItemsForUserRoleResult>(QueryBuilder.ExecuteStoredProcedure("SPC_GetMenuItemsForUserRole", userRole));
        }
    }
}
