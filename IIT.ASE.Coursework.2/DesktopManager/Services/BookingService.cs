using DesktopManager.Data_Repository;
using DesktopManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopManager.Services
{
    public class BookingService
    {
        private BookingRepository _bookingRepo;

        public BookingService()
        {
            _bookingRepo = new BookingRepository();
        }
        public IList<CBookingCustomer> LoadBookings()
        {
            return _bookingRepo.LoadBookings(); 
        }
    }
}
