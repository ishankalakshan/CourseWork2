using System.Collections.Generic;
using TabApplication.DataRepository;
using TabApplication.Models;

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
    }
}
