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

namespace TabApplication.Forms
{
    public partial class BookingInfo : Form
    {
        private int _seatId;
        private BookingService _bookingService;
        public BookingInfo()
        {
            InitializeComponent();
            _bookingService = new BookingService();
        }

        private void GetBookingInfo(int seatId)
        {
            var booking =_bookingService.SelectBookingBySeatId(seatId);

            txtrefNo.Text = booking.BookingId.ToString();
            txtName.Text = booking.CustomerName;
            txtNic.Text = booking.CustomerNic;
            txtEmail.Text = booking.CustomerEmail;
            txtMobile.Text = booking.CustomerTel;
            lblSeatStatus.Text = booking.BookingStatus.ToString();
        }

        public void MessageReceived(object sender, EventArgs e)
        {
            _seatId = (int)sender;
            lblSeatNo.Text = _seatId.ToString();
            GetBookingInfo(_seatId);
        }
    }
}
