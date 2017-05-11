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
            return  new SqlConnection("Server=tcp:iitstagecraftservertests.database.windows.net,1433;Initial Catalog=iitstagecraftremotetests;Persist Security Info=False;User ID=testadmin;Password=Intel@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        /// <summary>
        /// select a list f object from generic type
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="sql">sql query</param>
        /// <param name="parameters">query parameters</param>
        /// <returns>A set of data mapped to passed type</returns>
        public IList<T> Select<T>(string sql, object parameters = null)
        {
                using (var db = OpenDbConnection())
                {
                    var result = db.Query<T>(sql, parameters);
                    return result.ToList();
                }
        }
        /// <summary>
        /// Use this to update records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">Update query</param>
        /// <param name="parameters">update values as parameters</param>
        public void Update<T>(string sql, object parameters = null)
        {
            using (var db = OpenDbConnection())
            {
                var result = db.Query<T>(sql, parameters);
            }
        }

        /// <summary>
        /// returns affected number of rows
        /// </summary>
        /// <param name="sql">sql query to execute</param>
        /// <param name="parameters">parameters</param>
        /// <returns></returns>
        public int Execute(string sql, object parameters = null)
        {
            using (var db = OpenDbConnection())
            {
                var result = db.Execute(sql, parameters);
                return result;
            }
        }
    }
}