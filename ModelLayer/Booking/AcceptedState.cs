using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace ModelLayer.Booking
{
    public class AcceptedState : BookingState
    {
        public override void Accept(BookingContext booking)
        {
            //accepted booking cannot be accepted
        }

        public override void Cancel(BookingContext booking)
        {
            booking.TransitionToState(new CancelledState("Booking cancelled by user"));
        }

        public override void Create(BookingContext booking, DateTime moveInDate, DateTime moveOutDate)
        {
            //accepted booking cannot be created
        }

        public override void EnterState(BookingContext booking)
        {
            //send email to the student
        }
    }
}
