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

        //public async Task UpdateSeatStatusInLocalFromRemoteAsync()
        //{
        //    using (var client = _baseWebApi.CreateHttpClient())
        //    {
        //        var response = await client.GetAsync("api/GetSeatStatus");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result= await response.Content.ReadAsAsync<IList<Seat>>();
        //            _seatRepository.UpdateSeatStatusInLocalFromRemote(result);
        //            UpdateSeatStatusFromLocal();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Unable to connect to server");                 
        //        }
        //    }
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
