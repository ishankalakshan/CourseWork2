using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabApplication.Models;
using TabApplication.Services;
using TabApplication.Utility;

namespace TabApplication.Forms
{
    public partial class SeatView : Form
    {
        private readonly SeatService _seatService;
        private readonly BookingService _bookingService;
        public delegate void SendSeat(object obj, EventArgs e);
        public event SendSeat OnSendMessage;

        public SeatView()
        {
            InitializeComponent();
            _seatService = new SeatService();
            _bookingService = new BookingService();
            InitializeData();
            
            backgroundWorker1.RunWorkerAsync();
            UpdateSeatWorker.RunWorkerAsync();
        }

        private void LoadBookingForm(int seatId)
        {
            var child = new BookingForm();
            OnSendMessage += child.MessageReceived;
            child.Show();

            OnSendMessage?.Invoke(seatId, null);
        }

        private void LoadBookingInfoForm(int seatId)
        {
            var child = new BookingInfo();
            OnSendMessage += child.MessageReceived;
            child.Show();

            OnSendMessage?.Invoke(seatId, null);
        }

        public void InitializeData()
        {
            try
            {
                _seatService.CreateDbIfNotExists();
                SeedInitialSeatData();
                UpdateSeatStatus();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show("Error occured while loading the application.", "Error");
                throw;
            }
        }

        private void SeedInitialSeatData()
        {
            try
            {
                var seatObjs = new List<Seat>();
                var seats = gbSeatPlan.Controls.OfType<Button>();
                foreach (var seat in seats)
                {
                    var seatId = Convert.ToInt32(seat.Name.Substring(seat.Name.LastIndexOf('_') + 1));
                    seatObjs.Add(new Seat() { SeatId = seatId, SeatStatusId = 1 });
                }
                _seatService.LoadSeatsToLocalIfNotExists(seatObjs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void UpdateSeatStatus()
        {
            try
            {
                var seatsButtons = gbSeatPlan.Controls.OfType<Button>();
                var seats = _seatService.UpdateSeatStatusFromLocal();

                foreach (var button in seatsButtons)
                {
                    var seatId = Convert.ToInt32(button.Name.Substring(button.Name.LastIndexOf('_') + 1));
                    foreach (var seat in seats)
                    {
                        if (seat.SeatId == seatId)
                        {
                            UpdateButtonColor(button, seat);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void UpdateButtonColor(Button buttton,Seat seat)
        {
            if (seat.SeatStatusId==(int)StaticData.SeatStatusEnum.Available)
            {
                buttton.BackColor = Color.Lime;
            }
            else if (seat.SeatStatusId == (int)StaticData.SeatStatusEnum.Pending)
            {
                buttton.BackColor = Color.Yellow;
            }
            else if (seat.SeatStatusId == (int)StaticData.SeatStatusEnum.Reserved)
            {
                buttton.BackColor = Color.Orange;
            }
        }

        private void OnSeatClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var seatId = Convert.ToInt32(button.Name.Substring(button.Name.LastIndexOf('_') + 1));

            if (button.BackColor==Color.Lime)
            {
                LoadBookingForm(seatId);
            }
            else
            {
                LoadBookingInfoForm(seatId);
            }                     
        }
      
        public void SeatReceived(object sender, EventArgs e)
        {
            var seatId = (int)sender;

            var seatsButtons = gbSeatPlan.Controls.OfType<Button>();

            foreach (var seat in seatsButtons)
            {
                if (seat.Name=="seatId_"+seatId)
                {
                    UpdateButtonColor(seat, new Seat() { SeatStatusId = (int)StaticData.SeatStatusEnum.Pending });
                }
            }
        }

        //background worker used for uploading booking data and cancel booking data. It is called every 3 miniutes
        private void UploadBooking_Worker(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                     _bookingService.UploadBookingsToRemoteAsync();    
                     _bookingService.UploadCancelledBookingsToRemoteAsync();
                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error occured while uploading data to server.Record will be automatically uploaded when network is available.", "Network error");
            }                       
        }

        //use to fprce refresh seat status from local database
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            UpdateSeatStatus();          
        }

        //get uploaded pending bookings status
        private async Task GetUploadedPendingBookingStatusAsync()
        {
            await _bookingService.UpdatePendingBookingsFromRemoteAsync();
        }

        //this background worker is used to load seat status from local database. That methos is called every minute.
        private void UpdateSeatWorker_DoWorkAsync(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                    UpdateSeatStatus();
                    GetUploadedPendingBookingStatusAsync();
                    Thread.Sleep(30000);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured while retriving data from server.", "Network error");                
            }           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
