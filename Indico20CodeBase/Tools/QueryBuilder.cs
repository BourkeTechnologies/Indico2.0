using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Indico20CodeBase.Extensions;

namespace Indico20CodeBase.Tools
{
    public class QueryBuilder
    {
        public static string DeleteFromTable(string tableName, int id)
        {
            return string.Format("DELETE FROM [dbo].[{0}] WHERE ID = '{1}'",tableName,id);
        }

        public static string DeleteFromTable(string tableName, IEnumerable<int> ids)
        {
            var stringBuilder = new StringBuilder();
            foreach (var id in ids)
            {
                stringBuilder.Append(DeleteFromTable(tableName, id) + ";");
            }
            return stringBuilder.ToString();
        }

        public static string SelectAll(string tableName)
        {
            return string.Format("SELECT * FROM [dbo].[{0}]",tableName);
        }

        public static string Select(string tableName, int id)
        {
            return string.Format("SELECT * FROM [dbo].[{0}] WHERE ID = {1}", tableName, id);
        }

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
    }
}
