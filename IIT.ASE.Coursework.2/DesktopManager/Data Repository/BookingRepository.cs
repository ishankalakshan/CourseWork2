using Dapper;
using DesktopManager.Models;
using DesktopManager.Utility;
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

        public void UpdateBookingStatus(int bookingId,int statusId)
        {
            var queryParam = new { bookingId, statusId };
            var sql = "UPDATE Bookings SET BookingStatus=@statusId WHERE Id=@bookingId;";
            _baseRepo.Update(sql, queryParam);
        }

        public void UpdateSeatStatus(int seatId,int statusId)
        {
            var queryParam = new { seatId, statusId };
            var sql = "UPDATE Seats SET SeatStatusid=@statusId WHERE SeatId=@seatId;";
            _baseRepo.Update(sql, queryParam);
        }

        public bool IsSeatReserved(int seatId)
        {
            var queryParam = new { seatId };
            var sql = "select * from Seats where SeatId=@seatId";
            var status = _baseRepo.Select<Seat>(sql, queryParam).FirstOrDefault();

            if (status.SeatStatusId==(int)StaticData.SeatStatusEnum.Reserved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IList<int> GetSameSeatPendingBookingIds(int seatId)
        {
            var queryParam = new { seatId };
            var sql = "select bookings.Id from bookings join seats on bookings.seat_id=seats.id where seats.SeatId=@seatId and bookings.bookingStatus=2";
            return _baseRepo.Select<int>(sql,queryParam);
        }
    }
}
