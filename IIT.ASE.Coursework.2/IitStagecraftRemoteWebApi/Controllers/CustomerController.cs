using IitStagecraftRemoteWebApi.DataRepository;
using System;
using System.Web.Http;
using IitStagecraftRemoteWebApi.Models;

namespace IitStagecraftRemoteWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private BaseRepository _baseRepo = new BaseRepository();

        [HttpGet]
        [Route("api/GetCustomers")]
        public string GetCustomer(string sql,string customerNic)
        {
            var res = _baseRepo.Select<Seat>("Select * from Seats");
            try
            {
                return "Hello world";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
