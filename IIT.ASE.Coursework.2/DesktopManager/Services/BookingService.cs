using DesktopManager.Data_Repository;
using DesktopManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopManager.Forms;
using DesktopManager.Utility;

namespace DesktopManager.Services
{
    public class BookingService
    {
        private BookingRepository _bookingRepo;

        public BookingService()
        {
            _bookingRepo = new BookingRepository();
        }
        public IList<CBookingCustomer> LoadBookings(int statusId)
        {
            return _bookingRepo.LoadBookings(statusId); 
        }
        public Statistics GetStatistics()
        {
            var allData = _bookingRepo.GetAllSeats();
            var retObj = new Statistics()
            {
                TotalCount = allData.Count,
                AcceptedCount = allData.Count(b=>b.SeatStatusId==(int)StaticData.SeatStatusEnum.Reserved),
                PendingCount = allData.Count(b => b.SeatStatusId == (int)StaticData.SeatStatusEnum.Pending),
                AvailableCount = allData.Count(b => b.SeatStatusId == (int)StaticData.SeatStatusEnum.Available)
            };
            return retObj;
        }
    }
}
