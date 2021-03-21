using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace todoAPI.Helper
{ 
    public class TodoDbFactory
    {
        private static readonly object _lock = new object();
        private static TodoDbFactory _DbFactory;
        private readonly string connectionString;
        public TodoDbFactory()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory())).AddJsonFile("appsettings.json", optional: false).Build();
                connectionString = configuration.GetConnectionString("todoConnection"); 
            }
        }
        public static TodoDbFactory Singleton
        {
            get
            {
                if (_DbFactory == null)
                {
                    lock (_lock)
                    {
                        if (_DbFactory == null)
                        {
                            _DbFactory = new TodoDbFactory();
                        }
                    }
                }

                return _DbFactory;
            }
        }
        public string GetConnectionString()
        {
            return connectionString;
        }
        public IDbConnection OpenConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
