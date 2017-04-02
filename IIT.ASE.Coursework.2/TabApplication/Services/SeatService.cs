using System.IO;
using TabApplication.DataRepository;

namespace TabApplication.Services
{
    public class SeatService
    {
        SeatRepository _seatRepository;

        public SeatService()
        {
            _seatRepository = new SeatRepository();
        }

        public void createdb()
        {
             var res = File.Exists(BaseRepository.DbFile);
            if (!res)
            {
                _seatRepository.CreateTables();
            }

            _seatRepository.UpdateSeatStatusFromLocal();


        }
    }
}
