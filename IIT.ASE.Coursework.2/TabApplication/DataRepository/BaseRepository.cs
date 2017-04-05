using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TabApplication.DataRepository.Interface;

namespace TabApplication.DataRepository
{
    public class BaseRepository : IBaseRepository
    {
        public SQLiteConnection _sqlite_conn;
        public SQLiteCommand _sqlite_cmd;
        public SQLiteDataAdapter _sqliteDataAdapter;
        public static string DbFile => Environment.CurrentDirectory + "\\IitStageCraftLocal.db";

        public SQLiteConnection GetDbContextLocal()
        {
            return new SQLiteConnection("Data Source=IitStageCraftLocal.db;Version=3;New=True;Compress=True;");
        }
       
        public void CreateTables()
        {
            var CustomerTableString = "CREATE TABLE IF NOT EXISTS Customer(" +
               "CustomerId INTEGER PRIMARY KEY AUTOINCREMENT," +
               "CustomerNic varchar(20) NOT NULL," +
               "CustomerName varchar(100)," +
               "CustomerEmail varchar(30)," +
               "CustomerTel varchar(20)," +
               "DeviceId varchar(20));";

            var SeatTableString = "CREATE TABLE IF NOT EXISTS Seat(" +
                "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "SeatId INTEGER NOT NULL, " +
                "SeatStatusId INTEGER NOT NULL);";

            var BookingTableString = "CREATE TABLE IF NOT EXISTS Booking(BookingId INTEGER PRIMARY KEY AUTOINCREMENT,DeviceId varchar(20),SeatId INTEGER,CustomerId INTEGER,BookingStatus INTEGER NOT NULL,Uploaded BOOLEAN NOT NULL,FOREIGN KEY(SeatId) REFERENCES Seat(SeatId),FOREIGN KEY(CustomerId) REFERENCES Customer(CustomerId));";

            using (var db = GetDbContextLocal())
            {
                db.Open();
                _sqlite_cmd = db.CreateCommand();
                _sqlite_cmd.CommandText = CustomerTableString + SeatTableString + BookingTableString;
                _sqlite_cmd.ExecuteNonQuery();
                db.Close();
            }

        }

        public IList<T> Select<T>(string sql, object parameters=null,bool local = true)
        {
            if (local)
            {
                using (var db = GetDbContextLocal())
                {
                    var result = db.Query<T>(sql, parameters);
                    return result.ToList();
                }
            }
            else
            {
                return null;//For remote databse
            }                        
        }

        public void Insert(string sql, object parameters = null, bool local = true)
        {
            if (local)
            {
                using (var db = GetDbContextLocal())
                {
                    db.Execute(sql, parameters);
                }
            }
        }

        public int InsertSingle(string sql,object parameters=null,bool local = true)
        {
            if (local)
            {
                using (var db = GetDbContextLocal())
                {
                    return db.Query<int>(sql, parameters).First();
                }
            }
            else
            {
                return 0;
            }            
        }

        public void ExecuteScaler(string sql, object parameters=null)
        {
            using (var db = GetDbContextLocal())
            {
                db.ExecuteScalar(sql, parameters);
            }
        }
    }
}
