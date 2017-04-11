using System;
using System.Collections.Generic;
using System.Linq;
using TabApplication.Models;
using TabApplication.Models.Composite;
using TabApplication.Utility;

namespace TabApplication.DataRepository
{
    public class BookingRepository : BaseRepository
    {
        private readonly BaseRepository _baseRepository;

        public BookingRepository()
        {
            _baseRepository=new BaseRepository();
        }

        //insert customer record to local and retrieve Id
        public int InsertCustomerToLocal(Customer customer)
        {
            const string sql = "INSERT INTO Customer(CustomerNic,CustomerName,CustomerEmail,CustomerTel,DeviceId) " +
                               "VALUES(@CustomerNic,@CustomerName,@CustomerEmail,@CustomerTel,@DeviceId);SELECT last_insert_rowid();";
            return _baseRepository.InsertSingle(sql, customer);
        }

        //insert booking record to local and retrieve Id
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

        //update seat status in the local.Pass the enum status
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

        //selects the pending, not uploaded bookings from local and upload to remote 
        public IList<CBookingCustomer> SelectPendingBookingsToRemote()
        {
            var uploaded = false;
            var queryArgs = new
            {
                uploaded
            };
            var sql = "SELECT * FROM Booking JOIN Customer ON Customer.CustomerId=Booking.CustomerId WHERE Booking.Uploaded=@uploaded AND Booking.BookingStatus=2";
            return _baseRepository.Select<CBookingCustomer>(sql,queryArgs);
        }

        //after uploading to remote use this to set uplaoded flag 
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

        //select cancelled bookings to send to remote 
        internal IList<Booking> SelectCancelledBookingsToRemote()
        {
            var uploaded = false;
            var queryArgs = new
            {
                uploaded
            };
            var sql = "SELECT * FROM Booking WHERE Booking.Uploaded=@uploaded AND Booking.BookingStatus=4";
            return _baseRepository.Select<Booking>(sql, queryArgs);
        }

        //after uploading cancellations to remote use this to set uplaoded flag 
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

        //use to cancel bookings and save in local
        public void CancelBooking(int bookingId)
        {
            var queryArgs = new
            {
                BookingId = bookingId,
                BookingStatus = (int)StaticData.BookingStatusEnum.Cancelled,
                seatStatusId=(int)StaticData.SeatStatusEnum.Available
            };
            var sql = "UPDATE Booking SET BookingStatus=@BookingStatus,Uploaded=0 WHERE BookingId=@BookingId;UPDATE Seat SET SeatStatusId=@seatStatusId WHERE SeatId IN(SELECT SeatId FROM Booking WHERE BookingId=@BookingId);";
            _baseRepository.Update(sql, queryArgs);
        }
    }
}
