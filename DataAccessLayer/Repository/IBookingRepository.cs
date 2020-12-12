using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IBookingRepository
    {
        BookingModel Find(int id);

        IEnumerable<BookingModel> GetAll();

        BookingModel AddAnonymous(BookingModel booking);

        BookingModel Add(BookingModel booking, int studentId);

        int Update(BookingModel booking);

        int Remove(int id);

        IEnumerable<BookingModel> GetAllBookingsOfStatus(int status);

        int ChangeBookingStatus(BookingStatus bookingStatus, int id);

        int GetBookingStatus(int id);

    }
}
