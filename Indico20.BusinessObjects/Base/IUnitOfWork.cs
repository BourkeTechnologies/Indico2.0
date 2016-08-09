using System;
using System.Collections.Generic;

namespace Indico20.BusinessObjects.Base
{
    public interface IUnitOfWork
    {
        void Complete();
        void Remove(string tableName, int id);
        void RemoveRange(string tableName, IEnumerable<int> ids);
        void Add(string tableName, Dictionary<string, object> mapping);
        void AddRange(string tableName, List<Dictionary<string, object>> items);
        void Update(string tableName, Dictionary<string, object> values,int id);
    }
}
