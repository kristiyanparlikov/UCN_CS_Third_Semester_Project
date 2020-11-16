using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace ModelLayer.Booking
{
    public class LivingState : BookingState
    {
        public override void Accept(BookingContext booking)
        {
            //living state cannot be accepted
        }

        public override void Cancel(BookingContext booking)
        {
            booking.TransitionToState(new NoticeState());
        }

        public override void Create(BookingContext booking, DateTime moveInDate, DateTime moveOutDate)
        {
            throw new NotImplementedException();
        }

        public override void EnterState(BookingContext booking)
        {
            throw new NotImplementedException();
        }
    }
}
