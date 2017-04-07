using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TabApplication.DataRepository;
using TabApplication.Models;
using TabApplication.Models.Composite;
using TabApplication.Utility;

namespace TabApplication.Services
{
   public class BookingService
    {
        private readonly BookingRepository _bookingRepository;
        private readonly BaseWebApiCall _baseWebApi;
        public BookingService()
        {
            _bookingRepository = new BookingRepository();
            _baseWebApi = new BaseWebApiCall();
    }

        public int InsertCustomer(Customer customer)
        {
            var customerId = CheckWhetherUserExistsInLocal(customer);
            if (customerId!=0)
            {
                return customerId;
            }
            return _bookingRepository.InsertCustomerToLocal(customer);
        }

        public int CheckWhetherUserExistsInLocal(Customer customer)
        {
            var result = _bookingRepository.SelectCustomerByNic(customer.CustomerNic);
            if (result.Count>0)
            {
               return result.FirstOrDefault().CustomerId;
            }
            return 0;
        }

        public int InsertBookingToLocal(Booking booking)
        {
            var insertedBookingId = _bookingRepository.InsertBookingToLocal(booking);
            _bookingRepository.UpdateSeatStaus(booking.SeatId, (int)StaticData.SeatStatusEnum.Pending);
            return insertedBookingId;
        }

        public bool CheckWhetherUserExistsInRemote(Customer customer)
        {
            var result = _bookingRepository.SelectCustomerByNic(customer.CustomerNic,false).Count;
            return result > 0;
        }

        public async System.Threading.Tasks.Task UploadBookingsToRemoteAsync()
        {
            var tobeUpload = _bookingRepository.SelectPendingBookingsToRemote();
            if (tobeUpload.Count > 0)
            {
                foreach (var item in tobeUpload)
                {
                    
                    using (var client = _baseWebApi.CreateHttpClient())
                    {
                        var response = await client.PostAsJsonAsync("api/InsertOrUpdateCustomer", customer);
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsAsync<int>();
                            
                           
                        }                       
                    }

                }
            }
        }

        public CBookingCustomer SelectBookingBySeatId(int seatId)
        {
            return _bookingRepository.GetBookingInfo(seatId);
        }
    }
}
