using System.Collections.Generic;
using TabApplication.Models;

namespace TabApplication.DataRepository
{
    public class SeatRepository : BaseRepository
    {
        private readonly BaseRepository _baseRepository;

        public SeatRepository()
        {
            _baseRepository = new BaseRepository();
        }

        //load seat status from the local database
        public IList<Seat> UpdateSeatStatusFromLocal()
        {
            const string sql = "SELECT * FROM Seat";
            return _baseRepository.Select<Seat>(sql);
        }

        //Seed initial seat ids
        public void InitializeSeatsInLocalDb(List<Seat> seats)
        {
            const string sql = "INSERT INTO Seat(SeatId,SeatStatusId) VALUES(@SeatId,@SeatStatusId)";
            _baseRepository.Insert(sql,seats);
        }

        public bool IsInitialSeatDataPresentInLocal()
        {
            const string sql = "SELECT * FROM Seat";
            return _baseRepository.Select<Seat>(sql).Count>0;
        }
    }
}
