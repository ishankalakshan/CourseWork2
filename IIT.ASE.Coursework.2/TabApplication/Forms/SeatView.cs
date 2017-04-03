using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TabApplication.Models;
using TabApplication.Services;

namespace TabApplication.Forms
{
    public partial class SeatView : Form
    {
        private SeatService _SeatService;

        public SeatView()
        {
            InitializeComponent();
            _SeatService = new SeatService();
            tempload();
        }

        public void tempload()
        {
            //_SeatService.createdb();
            SeedInitialSeatData();
        }

        private void SeedInitialSeatData()
        {
            var seatIds = new List<Seat>();
            var seats = gbSeatPlan.Controls.OfType<Button>();
            foreach (var seat in seats)
            {
                var seatId = Convert.ToInt32(seat.Name.Substring(seat.Name.LastIndexOf('_') + 1));
                seatIds.Add(new Seat(){SeatId = seatId,SeatStatusId = 1});
            }
        }
    }
}
