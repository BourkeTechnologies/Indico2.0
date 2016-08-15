using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Indico20CodeBase.Tools
{
    public class EncryptionTool
    {
        /// <summary>
        /// Encrypt given text 
        /// </summary>
        /// <param name="password">text to encrypt </param>
        /// <param name="salt">salt</param>
        /// <returns></returns>
        public static string EncryptPassword(string password, string salt)
        {
            var bytes = Encoding.Unicode.GetBytes(password);
            var src = Convert.FromBase64String(salt);
            return Convert.ToBase64String(new SHA1Managed().ComputeHash(src.Concat(bytes).ToArray()));
        }
    }
}
