using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public SeatView()
        {
            InitializeComponent();
            _seatService = new SeatService();
            InitializeDataAsync();
        }

        public async Task InitializeDataAsync()
        {
            _seatService.CreateDbIfNotExists();
            SeedInitialSeatData();
            UpdateSeatStatus();
            await UpdateSeatsinLocalDbAsync();
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

        private void OnSeatClickAsync(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var seatId = Convert.ToInt32(button.Name.Substring(button.Name.LastIndexOf('_') + 1));
            MessageBox.Show(seatId.ToString());



            var res = testmethod();
        }

        private async Task testmethod()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:35903"); //http://iitstagecraftremotewebapi.azurewebsites.net
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ////GET Method  
                //HttpResponseMessage response = await client.GetAsync("api/GetSeatStatus");
                //if (response.IsSuccessStatusCode)
                //{
                //    var department = response.Content.ReadAsAsync<IList<Seat>>();

                //}
                //else
                //{
                //    MessageBox.Show("Internal server Error");
                //}
                var customer = new List<Customer>();
                customer.Add(new Customer() { CustomerId = 1, CustomerEmail = "asdgkjashd", CustomerName = "ishanka", CustomerNic = "adas", CustomerTel = "0988787" });
                var a = new Customer() { CustomerNic = "912701395v", CustomerEmail = "123qweaasd", CustomerName = "Ishanka", CustomerTel = "123123" };
                HttpResponseMessage response = await client.PostAsJsonAsync("api/InsertOrUpdateCustomer", a);

                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.  
                    Uri returnUrl = response.Headers.Location;
                    var department = response.Content.ReadAsAsync<int>();
                    Console.WriteLine(returnUrl);
                }
            }
        }

        private async Task UpdateSeatsinLocalDbAsync()
        {
            await _seatService.UpdateSeatStatusInLocalFromRemoteAsync();
        }
    }
}
