using TabApplication.Models;

namespace TabApplication.DataRepository
{
    public class SeatRepository : BaseRepository
    {
        private BaseRepository _baseRepository;

        public SeatRepository()
        {
            _baseRepository = new BaseRepository();
        }

        public void UpdateSeatStatusFromLocal()
        {
            var sql = "SELECT * FROM Seat";
            var res = _baseRepository.Select<Seat>(sql);
        }
    }
}
