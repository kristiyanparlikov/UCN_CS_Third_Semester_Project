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
        public abstract void EnterState(BookingModel booking);

        public abstract void Create(BookingModel booking, DateTime moveInDate, DateTime moveOutDate);

        public abstract void Cancel(BookingModel booking);

        public abstract void Accept(BookingModel booking);

        // We should probably have a fifth method for date passing 
        // -> if move-in date have already passed then the booking should change state to cancelled



    }
}
