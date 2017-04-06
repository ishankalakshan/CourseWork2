using System.Collections.Generic;
using System.Windows.Forms;
using TabApplication.Models;
using TabApplication.Services;
using TabApplication.Utility;

namespace TabApplication.Forms
{
    public partial class BookingForm : Form
    {
        private readonly BookingService _bookingService;
        public BookingForm()
        {
            InitializeComponent();
            _bookingService = new BookingService();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            var seatid = 100;
            var b =new Customer() {CustomerNic="912701397v",CustomerName="ishanka",CustomerTel="0716405220",CustomerEmail="Isankalakshan@gmail.com" };
            var a = _bookingService.InsertCustomer(b);
            var deviceId = UtilityMethod.GetMACAddress();
            var booking = new Booking() { BookingStatus = (int)StaticData.BookingStatusEnum.Pending,CustomerId = a, DeviceId = deviceId,SeatId = seatid, Uploaded = false};

            if (a==0)
            {
                MessageBox.Show("Exists");
            }
            else
            {
                _bookingService.InsertBookingToLocal(booking);
            }

            

            

        }
    }
}
