using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace IitStagecraftRemoteWebApi.DataRepository
{
    public class BaseRepository
    {
        public SqlConnection OpenDbConnection()
        {
            return  new SqlConnection("Server=tcp:iitstagecraftserver.database.windows.net,1433;Initial Catalog=iitstagecraftremote;Persist Security Info=False;User ID=testadmin;Password=Intel@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public IList<T> Select<T>(string sql, object parameters = null)
        {
                using (var db = OpenDbConnection())
                {
                    var result = db.Query<T>(sql, parameters);
                    return result.ToList();
                }
        }
    }
}