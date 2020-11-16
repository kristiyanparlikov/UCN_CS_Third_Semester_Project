using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace ModelLayer.Booking
{
    public abstract class BookingState
    {
        public abstract void EnterState(BookingContext booking);

        public abstract void Create(BookingContext booking, DateTime moveInDate, DateTime moveOutDate);

        public abstract void Cancel(BookingContext booking);

        public abstract void Accept(BookingContext booking);






    }
}
