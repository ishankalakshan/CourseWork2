using System.Data.SQLite;
using TabApplication.DataRepository.Interface;

namespace TabApplication.DataRepository
{
    public class BaseRepository : IBaseRepository
    {
        private SQLiteConnection _sqlite_conn;
        private SQLiteCommand _sqlite_cmd;
        private SQLiteDataAdapter _sqliteDataAdapter;

        public BaseRepository()
        {
            _sqlite_conn = new SQLiteConnection("Data Source=IitStageCraft.db;Version=3;New=True;Compress=True;");
        }

        public void CreateTables()
        {
            _sqlite_cmd = _sqlite_conn.CreateCommand();
            _sqlite_conn.Open();

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

            _sqlite_cmd.CommandText = CustomerTableString + SeatTableString + BookingTableString;
            _sqlite_cmd.ExecuteNonQuery();
            _sqlite_conn.Close();
        }
    }
}
