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

        BookingModel Add(BookingModel booking);

        BookingModel Update(BookingModel booking);

        void Remove(int id);

    }
}
