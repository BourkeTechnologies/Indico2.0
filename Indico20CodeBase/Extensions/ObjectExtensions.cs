using System;
using System.Globalization;
using System.Linq.Expressions;

namespace Indico20CodeBase.Extensions
{
    /// <summary>
    /// this class contains some extension methods for all objects
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Check the object is numeric type (if it is a string it will be formatted)
        /// </summary>
        /// <param name="obj">object to check if it is a numeric type</param>
        /// <returns>true or false</returns>
        public static bool IsNumeric(this object obj)
        {
            if (obj == null)
                return false;
            double number;
            return double.TryParse(Convert.ToString(obj, CultureInfo.InvariantCulture), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);
        }

        /// <summary>
        /// Get the name of a static or instance property from a property access lambda.
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="propertyLambda">lambda expression of the form: '() => Class.Property' or '() => object.Property'</param>
        /// <returns>The name of the property</returns>
        public static string GetPropertyName<T>(this object obj, Expression<Func<T>> propertyLambda) where T : class
        {
            var me = propertyLambda.Body as MemberExpression;
            if (me == null)
                throw new ArgumentException("must pass a lambda of the form () => object.Property'");
            return me.Member.Name;
        }
    }
}
