using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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

        //public bool CheckWhetherUserExistsInRemote(Customer customer)
        //{
        //    var result = _bookingRepository.SelectCustomerByNic(customer.CustomerNic).Count;
        //    return result > 0;
        //}

        public async Task UploadBookingsToRemoteAsync()
        {
            try
            {
                var tobeUpload = _bookingRepository.SelectPendingBookingsToRemote();
                if (tobeUpload.Count > 0)
                {
                    using (var client = _baseWebApi.CreateHttpClient())
                    {
                        var response = await client.PostAsJsonAsync("api/InsertBooking", tobeUpload);
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsAsync<IList<Booking>>();
                            UpdateBookingStatusAndSeatStatus(result);                           
                        }
                    }
                }
            }
            catch (System.Exception e)
            {

                throw e;
            }
            
        }

        public async Task UploadCancelledBookingsToRemoteAsync()
        {
            try
            {
                var tobeUpload = _bookingRepository.SelectCancelledBookingsToRemote(); ;
                if (tobeUpload.Count > 0)
                {
                    using (var client = _baseWebApi.CreateHttpClient())
                    {
                        var response = await client.PostAsJsonAsync("api/CancelBooking", tobeUpload);
                        if (response.IsSuccessStatusCode)
                        {
                            _bookingRepository.UpdateBookingStatus(tobeUpload);
                        }
                        else
                        {
                            Debug.WriteLine("Failed");
                        }
                    }
                }
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        public void UpdateBookingStatusAndSeatStatus(IList<Booking> bookings)
        {
            var seats = new List<Seat>();
            _bookingRepository.UpdateBookingStatus(bookings);

            foreach (var item in bookings)
            {
                if (item.BookingStatus==(int)StaticData.BookingStatusEnum.Accepted)
                {
                    seats.Add(new Seat() { SeatId = item.SeatId, SeatStatusId = (int)StaticData.SeatStatusEnum.Reserved });
                }
                if (item.BookingStatus == (int)StaticData.BookingStatusEnum.Pending)
                {
                    seats.Add(new Seat() { SeatId = item.SeatId, SeatStatusId = (int)StaticData.SeatStatusEnum.Pending });
                }
                if (item.BookingStatus == (int)StaticData.BookingStatusEnum.Rejected)
                {
                    seats.Add(new Seat() { SeatId = item.SeatId, SeatStatusId = (int)StaticData.SeatStatusEnum.Reserved });
                }
                if (item.BookingStatus == (int)StaticData.BookingStatusEnum.Cancelled)
                {
                    seats.Add(new Seat() { SeatId = item.SeatId, SeatStatusId = (int)StaticData.SeatStatusEnum.Available });
                }
            }

            _bookingRepository.UpdateSeatStatus(seats);
        }

        public CBookingCustomer SelectBookingBySeatId(int seatId)
        {
            return _bookingRepository.GetBookingInfo(seatId);
        }

        public async System.Threading.Tasks.Task<Customer> SearchForCustomerNicAsync(string Nic)
        {
            var result = _bookingRepository.SelectCustomerByNic(Nic);
            if (result.Count>0)
            {
                return result.FirstOrDefault();
            }
            else
            {
                using (var client = _baseWebApi.CreateHttpClient())
                {
                    var response = await client.PostAsJsonAsync("api/GetCustomer", Nic);
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.Content!=null)
                        {
                            return await response.Content.ReadAsAsync<Customer>();
                        }
                        else
                        {
                            return null;
                        }
                        
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void CancelBooking(int bookingId)
        {
            _bookingRepository.CancelBooking(bookingId);
        }


    }
}
