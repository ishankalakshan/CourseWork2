using System.Collections.Generic;
using System.IO;
using TabApplication.DataRepository;
using TabApplication.Models;

namespace TabApplication.Services
{
    public class SeatService
    {
        private readonly SeatRepository _seatRepository;

        public SeatService()
        {
            _seatRepository = new SeatRepository();
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

        //public IList<Seat> UpdateSeatStatusInLocalFromRemote()
        //{

        //}

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
