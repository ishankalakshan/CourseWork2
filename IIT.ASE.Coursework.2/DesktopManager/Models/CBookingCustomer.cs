using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopManager.Models
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

        public string StatusName
        {
            get
            {
                if (BookingStatus==1)
                {
                    return "Pending";
                }
                if (BookingStatus == 2)
                {
                    return "Pending";
                }
                if (BookingStatus == 3)
                {
                    return "Rejected";
                }
                if (BookingStatus == 4)
                {
                    return "Cancelled";
                }
                return "Pending";
            }
        }
    }
}
