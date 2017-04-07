using IitStagecraftRemoteWebApi.DataRepository;
using System;
using System.Web.Http;
using IitStagecraftRemoteWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace IitStagecraftRemoteWebApi.Controllers
{
    public class BookingController : ApiController
    {
        private BaseRepository _baseRepo = new BaseRepository();

        public int InsertOrUpdateCustomer(Customer customer)
        {
            var res = _baseRepo.Select<Seat>("Select * from Customers WHERE CustomerNic=@CustomerNic", customer);
            if (res.Count == 0)
            {
                var sql = "INSERT INTO Customers(CustomerNic,CustomerName,CustomerEmail,CustomerTel)" +
                    "VALUES (@CustomerNic,@CustomerName,@CustomerEmail,@CustomerTel);SELECT CAST(SCOPE_IDENTITY() as int)";
                return _baseRepo.Select<int>(sql, customer).Single();
            }
            else
            {
                var sql = "UPDATE Customers SET CustomerName=@CustomerName,CustomerEmail=@CustomerEmail,CustomerTel=@CustomerTel WHERE CustomerNic=@CustomerNic;" +
                    "SELECT Id FROM Customers WHERE CustomerNic=@CustomerNic";
                return _baseRepo.Select<int>(sql, customer).Single();
            }
        }

        [HttpPost]
        [Route("api/InsertBooking")]
        public List<int> InsertBooking(IList<CBookingCustomer> cbooking)
        {
            var idlist = new List<int>();
            foreach (var cb in cbooking)
            {
                var customer = new Customer() { CustomerNic = cb.CustomerNic, CustomerEmail = cb.CustomerEmail, CustomerName = cb.CustomerName, CustomerTel = cb.CustomerTel };
                
                var customerId = InsertOrUpdateCustomer(customer);
                
                var getseatId = _baseRepo.Select<int>("select Id from Seats where seatid="+cb.SeatId).Single();

                var booking = new Booking() { BookingId = cb.BookingId, DeviceId = cb.DeviceId, SeatId = getseatId, CustomerId = customerId, BookingStatus = cb.BookingStatus };
                var sql = "INSERT INTO Bookings(BookingId,DeviceId,BookingStatus,Customer_Id,Seat_Id) " +
                          "VALUES(@BookingId,@DeviceId,@BookingStatus,@CustomerId,@SeatId)";

                var result =_baseRepo.Insert(sql, booking);

                if (result>0)
                {
                    idlist.Add(booking.BookingId);
                }
            }
            return idlist;

        }

        public void GetBookingUpdates(IList<BookingUpdate> bookingList)
        {
            var sql = "SELECT * FROM Bookings WHERE BookingId=@BookingId AND DeviceId=@DeviceId";
            _baseRepo.Select<BookingUpdate>(sql, bookingList);
        }

    }
}
