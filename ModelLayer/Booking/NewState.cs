using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace ModelLayer.Booking
{
    public class NewState : BookingState
    {
        public override void Accept(BookingContext booking)
        {
            //new booking cannot be accepted
        }

        public override void Cancel(BookingContext booking)
        {
            booking.TransitionToState(new CancelledState("Booking canceled by student"));
        }

        public override void Create(BookingContext booking, DateTime moveInDate, DateTime moveOutDate)
        {
            booking.MoveInDate = moveInDate;
            booking.MoveOutDate = moveOutDate;
        }

        public override void EnterState(BookingContext booking)
        {
            
        }
    }
}
