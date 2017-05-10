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
            GetDashBoard();

        }

        public void LoadData()
        {
            var data = _bookingService.LoadBookings((int)cbRequestStatus.SelectedValue);
            dataGridView1.AutoGenerateColumns = false;            
            //dataGridView1.DataMember = 
            //dataGridView1.Columns[1].Name = "Category";
            //dataGridView1.Columns[2].Name = "Main Ingredients";
            //dataGridView1.Columns[3].Name = "Rating";
            dataGridView1.DataSource = data;          
        }

        private void GetDashBoard()
        {
            var res =_bookingService.GetStatistics();

            //this.chart1.ChartAreaType = ChartAreaType.Pie;
            //PieSeries series = new PieSeries();
            //series.DataPoints.Add(new PieDataPoint(60, "UK"));
            //series.DataPoints.Add(new PieDataPoint(90, "Japan"));
            //series.DataPoints.Add(new PieDataPoint(35, "Italy"));
            //series.DataPoints.Add(new PieDataPoint(85, "US"));
            //series.ShowLabels = true;
            //this.chart1.Series.Add(series);
            chart1.Series[0].Points.Add(new DataPoint(0, res.AcceptedCount) { LegendText="Reserved",Color=Color.Red});
            chart1.Series[0].Points.Add(new DataPoint(0, res.PendingCount) { LegendText = "Pending", Color = Color.Yellow });
            chart1.Series[0].Points.Add(new DataPoint(0, res.AvailableCount) { LegendText = "Available", Color = Color.Green });
            //chart1.Series[0].Label = "#VALX #PERCENT{P0}";
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
        }
    }
}
