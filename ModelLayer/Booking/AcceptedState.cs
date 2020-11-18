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
        public override void Accept(BookingModel booking)
        {
            //accepted booking cannot be accepted
        }

        public override void Cancel(BookingModel booking)
        {
            booking.TransitionToState(new CancelledState("Booking cancelled by user"));
        }

        public override void Create(BookingModel booking, DateTime moveInDate, DateTime moveOutDate)
        {
            //accepted booking cannot be created
        }

        public override void EnterState(BookingModel booking)
        {
            booking.Status = "Accepted";
        }
    }
}
