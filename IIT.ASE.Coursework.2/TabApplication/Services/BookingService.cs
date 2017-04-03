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
            if (CheckWhetherUserExists(customer))
            {
                return false;
            }
            else
            {             
                _bookingRepository.InsertCustomerToLocal(customer);
                return true;
            }          
        }

        public bool CheckWhetherUserExists(Customer customer)
        {
            var result = _bookingRepository.SelectCustomer(customer.CustomerNic).Count;
            return result > 0;
        }

    }
}
