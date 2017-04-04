using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IitStagecraftRemoteWebApi.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/Test")]
        public string GetMessage()
        {
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
