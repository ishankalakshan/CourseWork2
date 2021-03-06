﻿using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;

namespace DesktopManager.Data_Repository
{
    public class BaseRepository
    {
        public SqlConnection OpenDbConnection()
        {
            return new SqlConnection("Server=tcp:iitstagecraftserver.database.windows.net,1433;Initial Catalog=iitstagecraftremote;Persist Security Info=False;User ID=testadmin;Password=Intel@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public IList<T> Select<T>(string sql, object parameters = null)
        {
            using (var db = OpenDbConnection())
            {
                var result = db.Query<T>(sql, parameters);
                return result.ToList();
            }
        }

        public int Insert(string sql, object parameters = null)
        {
            using (var db = OpenDbConnection())
            {
                var result = db.Execute(sql, parameters);
                return result;
            }
        }
    }
}
