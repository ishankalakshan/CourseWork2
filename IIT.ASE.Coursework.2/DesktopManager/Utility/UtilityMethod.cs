using DesktopManager.Models;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopManager.Utility
{
    public class UtilityMethod
    {
        public static void UpdateButtonColor(Button buttton, Seat seat)
        {
            if (seat.SeatStatusId == (int)StaticData.SeatStatusEnum.Available)
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
    }
}
