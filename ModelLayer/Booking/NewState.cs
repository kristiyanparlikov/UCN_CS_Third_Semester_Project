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
        public override void Accept(BookingModel booking)
        {
            //new booking cannot be accepted
        }

        public override void Cancel(BookingModel booking)
        {
            booking.TransitionToState(new CancelledState("Booking canceled by student"));
        }

        public override void Create(BookingModel booking, DateTime moveInDate, DateTime moveOutDate)
        {
            booking.MoveInDate = moveInDate;
            booking.MoveOutDate = moveOutDate;
        }

        public override void EnterState(BookingModel booking)
        {
            
        }
    }
}
