using IitStagecraftRemoteWebApi.DataRepository;
using IitStagecraftRemoteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IitStagecraftRemoteWebApi.Controllers
{
    public class SeatController : ApiController
    {
        private BaseRepository _baseRepo = new BaseRepository();

        [HttpGet]
        [Route("api/GetSeatStatus")]
        public IList<Seat> GetSeatStatus()
        {
            try
            {
                return _baseRepo.Select<Seat>("Select * from Seats");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
