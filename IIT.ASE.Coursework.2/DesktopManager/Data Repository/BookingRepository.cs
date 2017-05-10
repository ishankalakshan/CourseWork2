using Dapper;
using DesktopManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopManager.Data_Repository
{
    public class BookingRepository
    {
        private BaseRepository _baseRepo;

        public BookingRepository()
        {
            _baseRepo = new BaseRepository();
        }

        public IList<CBookingCustomer> LoadBookings(int statusId)
        {
            var sql = "select Bookings.Id as BookingId,Bookings.DeviceId,Bookings.BookingStatus,Customers.CustomerName," +
                "customers.customernic,customers.CustomerEmail,customers.Customertel," +
                "seats.seatid " +
                "from Bookings " +
                "join customers on customers.id = bookings.customer_id " +
                "join Seats on Seats.id = bookings.seat_id " +
                "where Bookings.BookingStatus="+statusId;

            return _baseRepo.Select<CBookingCustomer>(sql);
        }

        public IList<Seat> GetAllSeats()
        {
            var sql = "SELECT * FROM Seats";
            return _baseRepo.Select<Seat>(sql);
        }

    }
}
