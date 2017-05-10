using DesktopManager.Services;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DesktopManager.Utility;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace DesktopManager.Forms
{
    public partial class Main : Form
    {
        private BookingService _bookingService;
        public Main()
        {
            InitializeComponent();
            _bookingService = new BookingService();
            BindStatusDropDown();
            LoadData();
            UpdateDTA.RunWorkerAsync();
           // GetDashBoard();

        }

        public void LoadData()
        {
            var data = _bookingService.LoadBookings((int)cbRequestStatus.SelectedValue);
            dataGridView1.AutoGenerateColumns = false;            
            dataGridView1.DataSource = data;          
        }

        private void GetDashBoard()
        {
            var res =_bookingService.GetStatistics();
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.Add(new DataPoint(0, res.AcceptedCount) { LegendText="Reserved",Color=Color.Red});
            chart1.Series[0].Points.Add(new DataPoint(0, res.PendingCount) { LegendText = "Pending", Color = Color.Yellow });
            chart1.Series[0].Points.Add(new DataPoint(0, res.AvailableCount) { LegendText = "Available", Color = Color.Green });
        }
        
        private void BindStatusDropDown()
        {
            cbRequestStatus.DisplayMember = "Value";
            cbRequestStatus.ValueMember = "Key";

            cbRequestStatus.DataSource = Enum.GetValues(typeof(StaticData.BookingStatusEnum))
                .Cast<StaticData.BookingStatusEnum>()
                .Select(p => new { Key = (int)p, Value = p.ToString() })
                .ToList();
        }

        private void UpdateDTA_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(30000);
                this.Invoke(new MethodInvoker(LoadData));                             
            }
        }

        private void cbRequestStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
            if ((int)cbRequestStatus.SelectedValue==(int)StaticData.BookingStatusEnum.Pending)
            {
                btnApprove.Visible = true;
            }
            else
            {
                btnApprove.Visible = false;
            }
        }

        private void btnSeatView_Click(object sender, EventArgs e)
        {
            new SeatView().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetDashBoard();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count==1)
            {
                var dialog = MessageBox.Show("By Aceppting this booking all the other booking to the " +
                    "same seat will be rejected automatically. Do you want to continue? ", 
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                var id = (int)dataGridView1.SelectedRows[0].Cells["BookingId"].Value;
                var seatId = (int)dataGridView1.SelectedRows[0].Cells["Seat"].Value;

                if (dialog== DialogResult.Yes)
                {
                    var result =_bookingService.UpdateBookingStatus(id, seatId);

                    if (result)
                    {
                        MessageBox.Show("Booking approved !");
                    }
                    else
                    {
                        MessageBox.Show("Booking Rejected !");
                    }
                }
            }
            else
            {
                MessageBox.Show("No booking selected.Please select a booking to approve.","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
