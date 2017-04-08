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

        private int InsertOrUpdateCustomer(Customer customer)
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
        public IList<Booking> InsertBooking(IList<CBookingCustomer> cbooking)
        {
            try
            {
                var insertedIds = new List<int>();
                foreach (var cb in cbooking)
                {
                    //Enter customer details related to the booking
                    var customer = new Customer() { CustomerNic = cb.CustomerNic, CustomerEmail = cb.CustomerEmail, CustomerName = cb.CustomerName, CustomerTel = cb.CustomerTel };
                    var customerId = InsertOrUpdateCustomer(customer);

                    //Get seat details related to the booking
                    Seat selectedseat;
                    bool isSeatAvailable;
                    GetSeatDetails(cb, out selectedseat, out isSeatAvailable);

                    //check for pending bookings for the seat
                    bool noPendingBookinsForSeat = GetPendingBookingsForSeat(selectedseat);

                    //Insert the booking to table and return the id
                    Booking booking;
                    int insertedBookingId;
                    InsertBookingAndReturnId(cb, customerId, selectedseat, out booking, out insertedBookingId);
                    insertedIds.Add(insertedBookingId);

                    //if there are not pending bookings and seat is available reserve the seat
                    if (noPendingBookinsForSeat && isSeatAvailable)
                    {
                        ReserveSeatAndUpdateBookingStatus(selectedseat, insertedBookingId,(int)StaticData.BookingStatusEnum.Accepted,(int)StaticData.SeatStatusEnum.Reserved);
                    }
                    else if(!isSeatAvailable)
                    {
                        ReserveSeatAndUpdateBookingStatus(selectedseat, insertedBookingId,(int)StaticData.BookingStatusEnum.Rejected, (int)StaticData.SeatStatusEnum.Reserved);
                    }
                }
                //get the updated booking details
                var updatedBookings = SelectUpdatedBookings(insertedIds);
                return updatedBookings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        private bool GetPendingBookingsForSeat(Seat selectedseat)
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

        private void InsertBookingAndReturnId(CBookingCustomer cb, int customerId, Seat selectedseat, out Booking booking, out int insertedBookingId)
        {
            booking = new Booking() { BookingId = cb.BookingId, DeviceId = cb.DeviceId, SeatId = selectedseat.Id, CustomerId = customerId, BookingStatus = cb.BookingStatus };
            var sql = "INSERT INTO Bookings(BookingId,DeviceId,BookingStatus,Customer_Id,Seat_Id) " +
                      "VALUES(@BookingId,@DeviceId,@BookingStatus,@CustomerId,@SeatId);SELECT CAST(SCOPE_IDENTITY() as int)";
            insertedBookingId = _baseRepo.Select<int>(sql, booking).Single();
        }

        private void GetSeatDetails(CBookingCustomer cb, out Seat selectedseat, out bool isSeatAvailable)
        {
            selectedseat = _baseRepo.Select<Seat>("select * from Seats where seatid=" + cb.SeatId).Single();
            isSeatAvailable = selectedseat.SeatStatusId == (int)StaticData.SeatStatusEnum.Available ? true : false;
        }

        private IList<Booking> SelectUpdatedBookings(IList<int> bookingids)
        {
           
                var sql3 = "select * from Bookings join seats on seats.Id=Bookings.seat_id where Bookings.Id IN(" + string.Join(",", bookingids.ToArray()) + ")";
                return _baseRepo.Select<Booking>(sql3);
        }

        private void ReserveSeatAndUpdateBookingStatus(Seat selectedseat, int insertedBookingId,int bookingStatus, int seatStatus)
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

        public void GetBookingUpdates(IList<BookingUpdate> bookingList)
        {
            var sql = "SELECT * FROM Bookings WHERE BookingId=@BookingId AND DeviceId=@DeviceId";
            _baseRepo.Select<BookingUpdate>(sql, bookingList);
        }

    }
}
