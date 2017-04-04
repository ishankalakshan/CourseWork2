using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TabApplication.Models;
using TabApplication.Services;
using TabApplication.Utility;

namespace TabApplication.Forms
{
    public partial class SeatView : Form
    {
        private readonly SeatService _seatService;

        public SeatView()
        {
            InitializeComponent();
            _seatService = new SeatService();
            InitializeData();
        }

        public void InitializeData()
        {
            _seatService.CreateDbIfNotExists();
            SeedInitialSeatData();
            UpdateSeatStatus();
        }

        private void SeedInitialSeatData()
        {
            var seatObjs = new List<Seat>();
            var seats = gbSeatPlan.Controls.OfType<Button>();
            foreach (var seat in seats)
            {
                var seatId = Convert.ToInt32(seat.Name.Substring(seat.Name.LastIndexOf('_') + 1));
                seatObjs.Add(new Seat(){SeatId = seatId,SeatStatusId = 1});
            }
            _seatService.LoadSeatsToLocalIfNotExists(seatObjs);
        }

        private void UpdateSeatStatus()
        {
            var seatsButtons = gbSeatPlan.Controls.OfType<Button>();
            var seats = _seatService.UpdateSeatStatusFromLocal();

            foreach (var button in seatsButtons)
            {
                var seatId = Convert.ToInt32(button.Name.Substring(button.Name.LastIndexOf('_') + 1));
                foreach (var seat in seats)
                {
                    if (seat.SeatId== seatId)
                    {
                        UpdateButtonColor(button,seat);
                    }
                }
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
                buttton.BackColor = Color.Red;
            }
        }

        private void OnSeatClick(object sender, EventArgs e)
        {
            var button = (Button) sender;
            var seatId = Convert.ToInt32(button.Name.Substring(button.Name.LastIndexOf('_') + 1));
            MessageBox.Show(seatId.ToString());
        }

    }
}
