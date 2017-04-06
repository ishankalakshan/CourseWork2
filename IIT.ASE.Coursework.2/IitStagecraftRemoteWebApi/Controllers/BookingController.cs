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

        [HttpPost]
        [Route("api/InsertOrUpdateCustomer")]
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
                var sql = "UPDATE Customers SET CustomerName=@CustomerName,CustomerEmail=@CustomerEmail,CustomerTel=@CustomerTel WHERE CustomerNic=@CustomerNic);" +
                    "SELECT Id FROM Customer WHERE CustomerNic=@CustomerNic";
                return _baseRepo.Select<int>(sql, customer).Single();
            }
        }

        public void InsertBooking(Booking booking)
        {
            var sql = "INSERT INTO Bookings(BookingId,DeviceId,BookingStatus,Customer_Id,Employee_Id,Seat_Id) " +
                      "VALUES(@BookingId,@DeviceId,@BookingStatus,@Customer_Id,@Employee_Id,@Seat_Id)";
        }

        public void GetBookingUpdates(IList<BookingUpdate> bookingList)
        {
            var sql = "SELECT * FROM Bookings WHERE BookingId=@BookingId AND DeviceId=@DeviceId";
            _baseRepo.Select<BookingUpdate>(sql, bookingList);
        }

    }
}
