using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indico20CodeBase.Extensions;

namespace Indico20CodeBase.Tools
{
    /// <summary>
    /// this class will help to build SQL queries easily
    /// </summary>
    /// <author>shanaka rusith</author>
    public class QueryBuilder
    {
        /// <summary>
        /// generate query for delete row from a table
        /// </summary>
        /// <param name="tableName">name of the table</param>
        /// <param name="id">id of the item</param>
        /// <returns>generated query</returns>
        public static string DeleteFromTable(string tableName, int id)
        {
            return string.Format("DELETE FROM [dbo].[{0}] WHERE ID = {1}",tableName,id);
        }

        /// <summary>
        /// delete range of items from a table
        /// </summary>
        /// <param name="tableName">name of the table</param>
        /// <param name="ids">list of ids to delete</param>
        /// <returns>generated query</returns>
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
        /// <returns>generated query</returns>
        public static string SelectAll(string tableName)
        {
            return string.Format("SELECT * FROM [dbo].[{0}]",tableName);
        }

        /// <summary>
        /// generate the query for select an specific item from a table  or a view
        /// </summary>
        /// <param name="tableName">name of the table</param>
        /// <param name="id">id to select</param>
        /// <returns>generated query</returns>
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
        /// <returns>generated query</returns>
        public static string Update(string tableName, Dictionary<string, object> values,int id)
        {
            if (values == null || values.Count < 1)
                return "";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("UPDATE [dbo].[{0}] SET ", tableName));
            var first = true;
            foreach (var key in values.Keys)
            {
                var value = values[key];
                var wrapper = value.IsNumeric()?"": "'";
                stringBuilder.Append(string.Format("{0}{1} = {2}{3}{4}",!first? ", ":"", string.Format("[{0}]",key), wrapper, (value is bool )?((bool)value).ToOneZero():value, wrapper));
                first = false;
            }
            stringBuilder.AppendLine(string.Format(" WHERE ID = {0}",id));
            return stringBuilder.ToString();
        }

        /// <summary>
        ///generates query for insert into a table 
        /// </summary>
        /// <param name="tableName">name of the table</param>
        /// <param name="values">dictionary that contains column name and value</param>
        /// <returns>generated query</returns>
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
                valuestrings.Add(string.Format("{0}{1}{2}",wrapper, (value is bool) ? ((bool)value).ToOneZero() : value, wrapper));
            }
           
            stringBuilder.Append(string.Format("({0}) VALUES({1});", GenerateColumnNameList(columnNames), valuestrings.Aggregate((c, n) => c + "," + n)));
            return stringBuilder.ToString();
        }

        /// <summary>
        /// generates query for execute stored procedure with parameters
        /// </summary>
        /// <param name="spName">name of the stored procedure</param>
        /// <param name="parameters">parameters for the procedure</param>
        /// <returns>generated query</returns>
        public static string ExecuteStoredProcedure(string spName, params object[] parameters)
        {
            if (string.IsNullOrWhiteSpace(spName))
                return "";
            var builder = new StringBuilder();
            var valuestrings = (from item in parameters let wrapper = item.IsNumeric() ? "" : "'" select string.Format("{0}{1}{2}", wrapper, (item is bool) ? ((bool)item).ToOneZero() : item, wrapper)).ToList();
            builder.Append(string.Format("EXEC [dbo].[{0}] {1}", spName, valuestrings.Aggregate((c, n) => c + "," + n)));
            return builder.ToString();
        }

        private static string GenerateColumnNameList(IEnumerable<string> columnNames)
        {
            var stringBuilder = new StringBuilder();
            foreach (var column in columnNames)
            {
                stringBuilder.AppendFormat("[{0}] ,", column);
            }
            return stringBuilder.ToString().TrimEnd(',');
        }
    }
}
