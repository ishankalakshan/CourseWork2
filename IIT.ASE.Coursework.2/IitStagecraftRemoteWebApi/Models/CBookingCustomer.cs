using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IitStagecraftRemoteWebApi.Models
{
    public class CBookingCustomer
    {
        public int BookingId { get; set; }
        public string DeviceId { get; set; }
        public int SeatId { get; set; }
        public int CustomerId { get; set; }
        public int BookingStatus { get; set; }
        public bool Uploaded { get; set; }
        public string CustomerNic { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerTel { get; set; }
    }
}