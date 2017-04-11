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
        private BaseRepository _baseRepo;
        private BookingRepository _bookingRepository;

        public BookingController()
        {
            _baseRepo = new BaseRepository();
            _bookingRepository = new BookingRepository();
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
                    var customerId = _bookingRepository.InsertOrUpdateCustomer(customer);

                    //Get seat details related to the booking
                    Seat selectedseat;
                    bool isSeatAvailable;
                    _bookingRepository.GetSeatDetails(cb, out selectedseat, out isSeatAvailable);

                    //check for pending bookings for the seat
                    bool noPendingBookinsForSeat = _bookingRepository.GetPendingBookingsForSeat(selectedseat);

                    //Insert the booking to table and return the id
                    Booking booking;
                    int insertedBookingId;
                    _bookingRepository.InsertBookingAndReturnId(cb, customerId, selectedseat, out booking, out insertedBookingId);
                    insertedIds.Add(insertedBookingId);

                    //if there are not pending bookings and seat is available reserve the seat
                    if (noPendingBookinsForSeat && isSeatAvailable)
                    {
                        _bookingRepository.ReserveSeatAndUpdateBookingStatus(selectedseat, insertedBookingId, (int)StaticData.BookingStatusEnum.Accepted, (int)StaticData.SeatStatusEnum.Reserved);
                    }
                    else if (!isSeatAvailable)
                    {
                        _bookingRepository.ReserveSeatAndUpdateBookingStatus(selectedseat, insertedBookingId, (int)StaticData.BookingStatusEnum.Rejected, (int)StaticData.SeatStatusEnum.Reserved);
                    }
                }
                //get the updated booking details
                var updatedBookings = _bookingRepository.SelectUpdatedBookings(insertedIds);
                return updatedBookings;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [HttpPost]
        [Route("api/GetCustomer")]
        public Customer SearchCustomer([FromBody] string Nic)
        {
            return _bookingRepository.SearchCustomer(Nic);
        }
        
        [HttpPost]
        [Route("api/CancelBooking")]
        public void CancelBooking(IList<Booking> booking)
        {
            _bookingRepository.CancelBooking(booking);
        }
       
    }
}
