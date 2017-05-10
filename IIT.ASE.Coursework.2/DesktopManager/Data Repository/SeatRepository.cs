using DesktopManager.Models;
using System.Collections.Generic;

namespace DesktopManager.Data_Repository
{
    public class SeatRepository
    {
        private readonly BaseRepository _baseRepository;
        public SeatRepository()
        {
            _baseRepository = new BaseRepository();
        }

        public IList<Seat> GetSeatStatus()
        {
            const string sql = "SELECT * FROM Seats";
            return _baseRepository.Select<Seat>(sql);
        }
    }
}
