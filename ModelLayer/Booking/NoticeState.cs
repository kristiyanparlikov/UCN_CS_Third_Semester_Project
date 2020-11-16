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
        public override void Accept(BookingContext booking)
        {
            //notice booking cannot be accepted
        }

        public override void Cancel(BookingContext booking)
        {
            throw new NotImplementedException();
        }

        public override void Create(BookingContext booking, DateTime moveInDate, DateTime moveOutDate)
        {
            //notice booking cannot be created
        }

        public override void EnterState(BookingContext booking)
        {
            booking.MoveOutDate = DateTime.UtcNow.AddMonths(3);
        }
    }
}
