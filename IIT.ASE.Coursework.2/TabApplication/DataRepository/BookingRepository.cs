using System.Collections.Generic;
using System.Linq;
using TabApplication.Models;
using TabApplication.Models.Composite;

namespace TabApplication.DataRepository
{
    public class BookingRepository : BaseRepository
    {
        private readonly BaseRepository _baseRepository;

        public BookingRepository()
        {
            _baseRepository=new BaseRepository();
        }

        public int InsertCustomerToLocal(Customer customer)
        {
            const string sql = "INSERT INTO Customer(CustomerNic,CustomerName,CustomerEmail,CustomerTel,DeviceId) " +
                               "VALUES(@CustomerNic,@CustomerName,@CustomerEmail,@CustomerTel,@DeviceId);SELECT last_insert_rowid();";
            return _baseRepository.InsertSingle(sql, customer);
        }

        public int InsertBookingToLocal(Booking booking)
        {
            const string sql = "INSERT INTO Booking(DeviceId,SeatId,CustomerId,BookingStatus,Uploaded) " +
                               "VALUES(@DeviceId,@SeatId,@CustomerId,@BookingStatus,@Uploaded);SELECT last_insert_rowid();";
            return _baseRepository.InsertSingle(sql, booking);
        }

        public IList<Customer> SelectCustomerByNic(string CustomerNic)
        {
            const string sql = "SELECT * FROM Customer WHERE CustomerNic=@CustomerNic";

            var queryArgs = new
            {
                CustomerNic
            };

            return _baseRepository.Select<Customer>(sql,queryArgs);
        }

        public void UpdateSeatStaus(int seatId,int seatStatus)
        {
            var queryArgs = new
            {
                seatId,seatStatus
            };
            var sql = "UPDATE Seat SET SeatStatusId=@seatStatus WHERE SeatId=@seatId";
            _baseRepository.ExecuteScaler(sql, queryArgs);
        }

        public CBookingCustomer GetBookingInfo(int seatId)
        {
            var queryArgs = new
            {
                seatId
            };
            var sql = "SELECT * FROM Booking JOIN Customer ON Customer.CustomerId=Booking.CustomerId WHERE SeatId=@seatId";
            return _baseRepository.Select<CBookingCustomer>(sql, queryArgs).FirstOrDefault();
        }

        public IList<CBookingCustomer> SelectPendingBookingsToRemote()
        {
            var uploaded = false;
            var queryArgs = new
            {
                uploaded
            };
            var sql = "SELECT * FROM Booking JOIN Customer ON Customer.CustomerId=Booking.CustomerId WHERE Uploaded=@uploaded";
            return _baseRepository.Select<CBookingCustomer>(sql,queryArgs);
        }

        public void UpdateUploadStatus(IList<int> bookingids)
        {
            var uploaded = true;
            var queryArgs = new
            {
                uploaded
            };
            var sql = "UPDATE Booking SET Uploaded=@uploaded WHERE BookingId IN(" + string.Join(",", bookingids.ToArray()) + ");";
            _baseRepository.ExecuteScaler(sql,queryArgs);
        }

        public void UpdateBookingStatus(IList<Booking> bookings)
        {
            var sql = "UPDATE Booking SET BookingStatus=@BookingStatus,Uploaded=1 WHERE BookingId=@BookingId;";         
            _baseRepository.Update(sql, bookings);
            
        }

        public void UpdateSeatStatus(IList<Seat> seats)
        {
            var sql2 = "UPDATE Seat SET SeatStatusId=@SeatStatusId WHERE SeatId=@seatId";
            _baseRepository.Update(sql2, seats);
        }
    }
}
