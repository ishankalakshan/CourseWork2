using System;
using System.Windows.Forms;
using TabApplication.Models;
using TabApplication.Services;
using TabApplication.Utility;

namespace TabApplication.Forms
{
    public partial class BookingForm : Form
    {
        private readonly BookingService _bookingService;
        public delegate void SendMessage(object obj, EventArgs e);
        public event SendMessage OnSendMessage;
        private string _deviceId;

        private int _seatId;
        public BookingForm()
        {
            InitializeComponent();
            _bookingService = new BookingService();
            _deviceId = UtilityMethod.GetMACAddress();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            if (Validate())
            {
                CreateBooking();
            }       
        }

        private void CreateBooking()
        {
            //var b =new Customer() {CustomerNic="912701397v",CustomerName="ishanka",CustomerTel="0716405220",CustomerEmail="Isankalakshan@gmail.com" };
            var customer = CreateCustomer();
            var localInsertedCustomerId = _bookingService.InsertCustomer(customer);
            var booking = new Models.Booking() { BookingStatus = (int)StaticData.BookingStatusEnum.Pending, CustomerId = localInsertedCustomerId, DeviceId = _deviceId, SeatId = _seatId, Uploaded = false };

            var insertedId = _bookingService.InsertBookingToLocal(booking);

            if (insertedId != 0)
            {
                PassMessagetoSeatView();
            }
        }

        private void PassMessagetoSeatView()
        {
            var child = (SeatView)Application.OpenForms["SeatView"];
            if (child != null)
            {
                OnSendMessage += child.SeatReceived;
                child.Show();

                OnSendMessage?.Invoke(_seatId, null);
            }
            else
            {
                child = new SeatView();
                OnSendMessage += child.SeatReceived;
                child.Show();

                OnSendMessage?.Invoke(_seatId, null);
            }
        }

        private Customer CreateCustomer()
        {
            return new Customer() { CustomerNic = txtNic.Text.Trim(), CustomerName = txtName.Text.Trim(), CustomerEmail = txtEmail.Text.Trim(), CustomerTel = txtMobile.Text.Trim() };
        }

        public void MessageReceived(object sender, EventArgs e)
        {
            _seatId = (int)sender;
        }

        private new bool Validate()
        {
            if (string.IsNullOrWhiteSpace(txtNic.Text))
            {
                MessageBox.Show("NIC cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                MessageBox.Show("Mobile number cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var result = await _bookingService.SearchForCustomerNicAsync(txtNic.Text.Trim().ToLower());
            if (result!=null)
            {
                txtEmail.Text = result.CustomerEmail;
                txtMobile.Text = result.CustomerTel;
                txtName.Text = result.CustomerName;
            }
            else
            {
                MessageBox.Show("No record found", "Search complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
