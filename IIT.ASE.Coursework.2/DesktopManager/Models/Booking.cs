using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopManager.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string DeviceId { get; set; }
        public int SeatId { get; set; }
        public int CustomerId { get; set; }
        public int BookingStatus { get; set; }
        public bool Uploaded { get; set; }
    }
}
