using System.Collections.Generic;
using System.Windows.Forms;
using TabApplication.Models;
using TabApplication.Services;

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
            var b =new Customer() {CustomerNic="912701397v",CustomerName="ishanka",CustomerTel="0716405220",CustomerEmail="Isankalakshan@gmail.com" };
            var a = _bookingService.InsertCustomer(b);

            if (!a)
            {
                MessageBox.Show("Exists");
            }


        }
    }
}
