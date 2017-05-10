using DesktopManager.Data_Repository;
using DesktopManager.Models;
using System.Collections.Generic;

namespace DesktopManager.Services
{
    public class SeatService
    {
        private readonly SeatRepository _seatRepository;
        public SeatService()
        {
            _seatRepository = new SeatRepository();
        }

        public IList<Seat> GetSeatStatus()
        {
            return _seatRepository.GetSeatStatus();
        }
    }
}
