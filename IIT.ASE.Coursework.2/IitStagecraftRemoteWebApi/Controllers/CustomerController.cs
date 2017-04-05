using IitStagecraftRemoteWebApi.DataRepository;
using System;
using System.Web.Http;
using IitStagecraftRemoteWebApi.Models;
using System.Collections.Generic;

namespace IitStagecraftRemoteWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private BaseRepository _baseRepo = new BaseRepository();

        [HttpPost]
        [Route("api/GetCustomers")]
        public string GetCustomer(List<Customer> customer)
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
