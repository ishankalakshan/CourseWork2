using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IitStagecraftRemoteWebApi
{
    public static class StaticData
    {
        public enum SeatStatusEnum
        {
            Available = 1,
            Pending = 2,
            Reserved = 3
        }

        public enum BookingStatusEnum
        {
            Accepted = 1,
            Pending = 2,
            Rejected = 3,
            Cancelled = 4
        }
    }
}