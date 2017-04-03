using System.Collections.Generic;
using System.IO;
using TabApplication.DataRepository;
using TabApplication.Models;

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
