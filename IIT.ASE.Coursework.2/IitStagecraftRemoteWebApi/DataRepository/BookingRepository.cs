using IitStagecraftRemoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IitStagecraftRemoteWebApi.DataRepository
{
    public class BookingRepository
    {
        private BaseRepository _baseRepo;

        public BookingRepository()
        {
            _baseRepo = new BaseRepository();
        }
        public void GetSeatDetails(CBookingCustomer cb, out Seat selectedseat, out bool isSeatAvailable)
        {
            selectedseat = _baseRepo.Select<Seat>("select * from Seats where seatid=" + cb.SeatId).Single();
            isSeatAvailable = selectedseat.SeatStatusId == (int)StaticData.SeatStatusEnum.Available ? true : false;
        }

        public int InsertOrUpdateCustomer(Customer customer)
        {
            var res = _baseRepo.Select<Customer>("Select * from Customers WHERE CustomerNic=@CustomerNic", customer);
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

        public bool GetPendingBookingsForSeat(Seat selectedseat)
        {
            var queryArgs = new
            {
                BookingStatus = (int)StaticData.BookingStatusEnum.Pending,
                SeatId = selectedseat.Id
            };

            var sql1 = "select count(*) from bookings where Bookingstatus=@BookingStatus and seat_id=@SeatId;";
            var noPendingBookinsForSeat = _baseRepo.Select<int>(sql1, queryArgs).Single() > 0 ? false : true;
            return noPendingBookinsForSeat;
        }

        public void InsertBookingAndReturnId(CBookingCustomer cb, int customerId, Seat selectedseat, out Booking booking, out int insertedBookingId)
        {
            booking = new Booking() { BookingId = cb.BookingId, DeviceId = cb.DeviceId, SeatId = selectedseat.Id, CustomerId = customerId, BookingStatus = cb.BookingStatus };
            var sql = "INSERT INTO Bookings(BookingId,DeviceId,BookingStatus,Customer_Id,Seat_Id) " +
                      "VALUES(@BookingId,@DeviceId,@BookingStatus,@CustomerId,@SeatId);SELECT CAST(SCOPE_IDENTITY() as int)";
            insertedBookingId = _baseRepo.Select<int>(sql, booking).Single();
        }

        public IList<Booking> SelectUpdatedBookings(IList<int> bookingids)
        {

            var sql3 = "select * from Bookings join seats on seats.Id=Bookings.seat_id where Bookings.Id IN(" + string.Join(",", bookingids.ToArray()) + ")";
            return _baseRepo.Select<Booking>(sql3);
        }

        public void ReserveSeatAndUpdateBookingStatus(Seat selectedseat, int insertedBookingId, int bookingStatus, int seatStatus)
        {
            var queryArgs2 = new
            {
                BookingStatus = bookingStatus,
                insertedBookingId,
                SeatId = selectedseat.Id,
                SeatStatusId = seatStatus
            };
            var sql2 = "UPDATE Seats SET SeatStatusId=@SeatStatusId WHERE Id=@seatId;UPDATE Bookings SET Bookingstatus=@BookingStatus WHERE Id=@insertedBookingId;";
            _baseRepo.Execute(sql2, queryArgs2);
        }

        //public void GetBookingUpdates(IList<BookingUpdate> bookingList)
        //{
        //    var sql = "SELECT * FROM Bookings WHERE BookingId=@BookingId AND DeviceId=@DeviceId";
        //    _baseRepo.Select<BookingUpdate>(sql, bookingList);
        //}

        public void CancelBooking(IList<Booking> booking)
        {
            foreach (var item in booking)
            {
                var queryArgs2 = new
                {
                    BookingStatus = (int)StaticData.BookingStatusEnum.Cancelled,
                    deviceId = item.DeviceId,
                    bookingId = item.BookingId,
                    SeatStatusId = (int)StaticData.SeatStatusEnum.Available
                };
                var sql = "UPDATE Bookings SET Bookingstatus=@BookingStatus WHERE DeviceId=@deviceId AND BookingId=@bookingId;" +
                    "UPDATE Seats SET SeatStatusId=@SeatStatusId WHERE Id IN(SELECT Seat_Id FROM Bookings WHERE DeviceId=@deviceId AND BookingId=@bookingId);";
                _baseRepo.Execute(sql, queryArgs2);
            }

        }

        public Customer SearchCustomer(string Nic)
        {
            var queryargs = new
            {
                Nic
            };

            var result = _baseRepo.Select<Customer>("select * from customers where customernic=@Nic", queryargs);

            if (result.Count > 0)
            {
                return result.Single();
            }
            else
            {
                return null;
            }
        }
    }
}