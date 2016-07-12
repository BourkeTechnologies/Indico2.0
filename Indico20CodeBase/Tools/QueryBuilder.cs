using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indico20CodeBase.Extensions;

namespace Indico20CodeBase.Tools
{
    /// <summary>
    /// this class will help to build SQL queries easily
    /// </summary>
    public class QueryBuilder
    {
        /// <summary>
        /// generate query for delete row from a table
        /// </summary>
        /// <param name="tableName">name of the table</param>
        /// <param name="id">id of the item</param>
        /// <returns>string</returns>
        public static string DeleteFromTable(string tableName, int id)
        {
            return string.Format("DELETE FROM [dbo].[{0}] WHERE ID = '{1}'",tableName,id);
        }

        /// <summary>
        /// delete range of items from a table
        /// </summary>
        /// <param name="tableName">name of the table</param>
        /// <param name="ids">list of ids to delete</param>
        /// <returns>string</returns>
        public static string DeleteFromTable(string tableName, IEnumerable<int> ids)
        {
            var stringBuilder = new StringBuilder();
            foreach (var id in ids)
            {
                stringBuilder.Append(DeleteFromTable(tableName, id) + ";");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// generates the query for select all items from a table
        /// </summary>
        /// <param name="tableName">name of the table</param>
        /// <returns>string</returns>
        public static string SelectAll(string tableName)
        {
            return string.Format("SELECT * FROM [dbo].[{0}]",tableName);
        }

        /// <summary>
        /// generate the query for select an specific item from a table  or a view
        /// </summary>
        /// <param name="tableName">name of the table</param>
        /// <param name="id">id to select</param>
        /// <returns>string</returns>
        public static string Select(string tableName, int id)
        {
            return string.Format("SELECT * FROM [dbo].[{0}] WHERE ID = {1}", tableName, id);
        }

        /// <summary>
        /// creates an query for update item in the database
        /// </summary>
        /// <param name="tableName">name of the table</param>
        /// <param name="values">dictionary that contains column name and value</param>
        /// <param name="id">id of the item to update</param>
        /// <returns>string</returns>
        public static string Update(string tableName, Dictionary<string, object> values,int id)
        {
            if (values == null || values.Count < 1)
                return "";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("UPDATE FROM [dbo].[{0}] SET ", tableName));
            var first = true;
            foreach (var key in values.Keys)
            {
                var value = values[key];
                var wrapper = value.IsNumeric()?"": "'";
                stringBuilder.Append(string.Format("{0}{1} = {2}{3}{4}",!first? ", ":"", key, wrapper, value, wrapper));
                first = false;
            }
            stringBuilder.AppendLine(string.Format("WHERE ID = {0}",id));
            return stringBuilder.ToString();
        }

        /// <summary>
        ///generates query for insert into a table 
        /// </summary>
        /// <param name="tableName">name of the table</param>
        /// <param name="values">dictionary that contains column name and value</param>
        /// <returns>string</returns>
        public static string Insert(string tableName, Dictionary<string, object> values)
        {
            if (values == null || values.Count < 1)
                return "";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("INSERT INTO [dbo].[{0}] ", tableName));
            var columnNames = new List<string>();
            var valuestrings = new List<string>();
            foreach (var key in values.Keys)
            {
                var value = values[key];
                columnNames.Add(key);
                var wrapper = value.IsNumeric() ? "" : "'";
                valuestrings.Add(string.Format("{0}{1}{2}",wrapper,value,wrapper));
            }
           
            stringBuilder.Append(string.Format("({0}) VALUES({1});", columnNames.Aggregate((c, n)=>c+","+n), valuestrings.Aggregate((c, n) => c + "," + n)));
            return stringBuilder.ToString();
        }

        public static string ExecuteStoredProcedure(string spName, params object[] parameters)
        {
            if (string.IsNullOrWhiteSpace(spName))
                return "";
            var builder = new StringBuilder();
            var valuestrings = (from item in parameters let wrapper = item.IsNumeric() ? "" : "'" select string.Format("{0}{1}{2}", wrapper, item, wrapper)).ToList();
            builder.Append(string.Format("EXEC [dbo].[{0}] {1}", spName, valuestrings.Aggregate((c, n) => c + "," + n)));
            return builder.ToString();
        }
    }
}
