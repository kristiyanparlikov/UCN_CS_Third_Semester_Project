using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace ModelLayer.Booking
{
    public class NoticeState : BookingState
    {
        public override void Accept(BookingModel booking)
        {
            //notice booking cannot be accepted
        }
        public override void Cancel(BookingModel booking)
        {
            booking.TransitionToState(new CancelledState("3 months notice have expired"));
        }

        public override void Create(BookingModel booking, DateTime moveInDate, DateTime moveOutDate)
        {
            //notice booking cannot be created
        }

        public override void EnterState(BookingModel booking)
        {
            booking.Status = "Notice"; 
            booking.MoveOutDate = DateTime.UtcNow.AddMonths(3);
           
        }
    }
}
