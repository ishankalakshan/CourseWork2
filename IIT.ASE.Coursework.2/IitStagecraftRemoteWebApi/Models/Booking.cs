namespace IitStagecraftRemoteWebApi.Models 
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string DeviceId { get; set; }
        public int SeatId { get; set; }
        public int CustomerId { get; set; }
        public int BookingStatus { get; set; }
        public bool Uploaded { get; set; }
    }
}
