using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace DataAccessLayer.Repository
{
    public interface IBookingRepository
    {
        BookingModel Find(int id);

        List<BookingModel> GetAll();

        BookingModel AddAnonymous(BookingModel booking);

        BookingModel AddFull(BookingModel booking, StudentModel student);

        int Update(BookingModel booking);

        int Remove(int id);

    }
}
