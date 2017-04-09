using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabApplication.Models;
using TabApplication.Services;
using TabApplication.Utility;

namespace TabApplication.Forms
{
    public partial class BookingInfo : Form
    {
        private int _seatId;
        private BookingService _bookingService;
        private Booking _currentBooking;
        public BookingInfo()
        {
            InitializeComponent();
            _bookingService = new BookingService();
        }

        private void GetBookingInfo(int seatId)
        {
            var booking =_bookingService.SelectBookingBySeatId(seatId);

            if (booking!=null)
            {
                txtrefNo.Text = booking.BookingId.ToString();
                txtName.Text = booking.CustomerName;
                txtNic.Text = booking.CustomerNic;
                txtEmail.Text = booking.CustomerEmail;
                txtMobile.Text = booking.CustomerTel;
                lblSeatStatus.Text = GetBookingStatusName(booking.BookingStatus);
            }         
        }

        private string GetBookingStatusName(int statusId)
        {
            if (statusId==(int)StaticData.BookingStatusEnum.Accepted)
            {
                lblSeatStatus.BackColor = Color.Orange;
                return "Accepted";
            }else if (statusId == (int)StaticData.BookingStatusEnum.Pending)
            {
                lblSeatStatus.BackColor = Color.Yellow;
                return "Pending";
            }
            else if (statusId == (int)StaticData.BookingStatusEnum.Rejected)
            {
                lblSeatStatus.BackColor = Color.Red;
                return "Rejected";
            }
            else if (statusId == (int)StaticData.BookingStatusEnum.Cancelled)
            {
                lblSeatStatus.BackColor = Color.Orange;
                return "Cancelled";
            }
            else
            {
                return "";
            }
        }

        public void MessageReceived(object sender, EventArgs e)
        {
            _seatId = (int)sender;
            lblSeatNo.Text = _seatId.ToString();
            GetBookingInfo(_seatId);
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            var booking = CreateBookingObject();
            _bookingService.CancelBooking(booking.BookingId);
        }

        private Booking CreateBookingObject()
        {
            return new Booking() {BookingId=Convert.ToInt32(txtrefNo.Text),BookingStatus=(int)StaticData.BookingStatusEnum.Cancelled,DeviceId=UtilityMethod.GetMACAddress()};
        }
    }
}
