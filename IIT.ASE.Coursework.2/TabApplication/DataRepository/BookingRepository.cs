using System.Collections.Generic;
using TabApplication.Models;

namespace TabApplication.DataRepository
{
    public class BookingRepository : BaseRepository
    {
        private readonly BaseRepository _baseRepository;

        public BookingRepository()
        {
            _baseRepository=new BaseRepository();
        }

        public int InsertCustomerToLocal(Customer customer)
        {
            const string sql = "INSERT INTO Customer(CustomerNic,CustomerName,CustomerEmail,CustomerTel,DeviceId) " +
                               "VALUES(@CustomerNic,@CustomerName,@CustomerEmail,@CustomerTel,@DeviceId);SELECT last_insert_rowid();";
            return _baseRepository.InsertSingle(sql, customer, true);
        }

        public int InsertBookingToLocal(Booking booking)
        {
            const string sql = "INSERT INTO Booking(DeviceId,SeatId,CustomerId,BookingStatus,Uploaded) " +
                               "VALUES(@DeviceId,@SeatId,@CustomerId,@BookingStatus,@Uploaded);SELECT last_insert_rowid();";
            return _baseRepository.InsertSingle(sql, booking, true);
        }

        public IList<Customer> SelectCustomerByNic(string CustomerNic,bool local=true)
        {
            const string sql = "SELECT * FROM Customer WHERE CustomerNic=@CustomerNic";

            var queryArgs = new
            {
                CustomerNic
            };

            return _baseRepository.Select<Customer>(sql,queryArgs,local);
        }

    }
}
