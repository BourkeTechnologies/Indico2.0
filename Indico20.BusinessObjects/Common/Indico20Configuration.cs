using System;
using System.Configuration;

namespace Indico20.BusinessObjects.Common
{
    public class Indico20Configuration
    {
        private static Indico20Configuration _configuration;
        private static string _connectionString;

        private Indico20Configuration()
        {}

        public static Indico20Configuration AppSettings => _configuration ?? (_configuration = new Indico20Configuration());

        public string ConnectionString
        {
            get
            {
                if (!string.IsNullOrEmpty(_connectionString))
                    return _connectionString;

                string fromConfigurationFile;
                try{fromConfigurationFile = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;}
                catch (Exception){fromConfigurationFile = null;}
                _connectionString = string.IsNullOrEmpty(fromConfigurationFile) ? 
                    @"Data Source=MUFASA-PC\SQLEXPRESS;initial catalog=Indico2.0;Integrated Security=True" 
                    : fromConfigurationFile;
                return _connectionString;
            }
        }
    }
}
