using System.Collections.Generic;
using TabApplication.DataRepository;
using TabApplication.Models;
using TabApplication.Utility;

namespace TabApplication.Services
{
   public class BookingService
    {
        private readonly BookingRepository _bookingRepository;
        public BookingService()
        {
            _bookingRepository = new BookingRepository();
        }

        public bool InsertCustomer(Customer customer)
        {
            if (CheckWhetherUserExistsInLocal(customer))
            {
                return false;
            }
            else
            {             
                _bookingRepository.InsertCustomerToLocal(customer);
                return true;
            }          
        }

        public bool CheckWhetherUserExistsInLocal(Customer customer)
        {
            var result = _bookingRepository.SelectCustomer(customer.CustomerNic).Count;
            return result > 0;
        }

        public void InsertBookingToLocal(Booking booking)
        {
            var insertedBookingId = _bookingRepository.InsertBookingToLocal(booking);
        }

        public bool CheckWhetherUserExistsInRemote(Customer customer)
        {
            var result = _bookingRepository.SelectCustomer(customer.CustomerNic,false).Count;
            return result > 0;
        }

        public IList<Booking> SelectPendingBookingsToRemote()
        {
            var bookingStatus = (int)StaticData.BookingStatusEnum.Pending;
            var queryArgs = new
            {
                bookingStatus
            };
            var sql = "SELECT * FROM Booking WHERE BookingStatus=@bookingStatus AND Uploaded=false";
            return _bookingRepository.Select<Booking>(sql,queryArgs);
        }

        public void UploadBookingsToRemote()
        {
            var tobeUpload = SelectPendingBookingsToRemote();
            if (tobeUpload.Count>0)
            {
                //send the data to remote
            }
        }
    }
}
