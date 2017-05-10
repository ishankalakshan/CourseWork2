using DesktopManager.Services;
using DesktopManager.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopManager.Forms
{
    public partial class SeatView : Form
    {
        private readonly SeatService _seatService;
        public SeatView()
        {
            InitializeComponent();
            _seatService = new SeatService();
            LoadSeats();
        }

        private void LoadSeats()
        {
            try
            {
                var seatsButtons = gbSeatPlan.Controls.OfType<Button>();
                var seats = _seatService.GetSeatStatus();

                foreach (var button in seatsButtons)
                {
                    var seatid = Convert.ToInt32(button.Name.Substring(button.Name.LastIndexOf('_') + 1));
                    foreach (var seat in seats)
                    {
                        if (seat.SeatId == seatid)
                        {
                            UtilityMethod.UpdateButtonColor(button, seat);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
    } 
}
