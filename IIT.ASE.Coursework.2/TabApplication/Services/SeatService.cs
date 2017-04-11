using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabApplication.DataRepository;
using TabApplication.Models;

namespace TabApplication.Services
{
    public class SeatService
    {
        private readonly SeatRepository _seatRepository;
        private readonly BaseWebApiCall _baseWebApi;

        public SeatService()
        {
            _seatRepository = new SeatRepository();
            _baseWebApi = new BaseWebApiCall();
        }

        public void CreateDbIfNotExists()
        {
             var res = File.Exists(BaseRepository.DbFile);
            if (!res)
            {
                _seatRepository.CreateTables();
            }
        }

        public IList<Seat> UpdateSeatStatusFromLocal()
        {
            return _seatRepository.UpdateSeatStatusFromLocal();
        }

        public void LoadSeatsToLocalIfNotExists(List<Seat> seats)
        {
            var exists = _seatRepository.IsInitialSeatDataPresentInLocal();

            if (!exists)
            {
                _seatRepository.InitializeSeatsInLocalDb(seats);
            }
        }
    }
}
