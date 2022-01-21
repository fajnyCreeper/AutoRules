﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutoRules.Objects
{
    internal class DatabaseConfig
    {
        public string Host { get; }
        public string Database { get; }
        public string Username { get; }
        public string Password { get; }

        public DatabaseConfig(string host, string database, string username, string password)
        {
            Host = host;
            Database = database;
            Username = username;
            Password = password;
        }
    }
}
