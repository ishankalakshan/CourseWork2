using System.Windows.Forms;
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
            _SeatService.createdb();
        }
    }
}
