using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace ModelLayer.Booking
{
    public class PendingState : BookingState
    {
        public override void Accept(BookingContext booking)
        {
            //booking.TransitionToState(new DepositPaymentState());
        }

        public override void Cancel(BookingContext booking)
        {
            booking.TransitionToState(new CancelledState("Booking cancelled by admin"));
        }

        public override void Create(BookingContext booking, DateTime moveInDate, DateTime moveOutDate)
        {
            //pending booking cannot be created
        }

        public override void EnterState(BookingContext booking)
        {
            
        }
    }
}
