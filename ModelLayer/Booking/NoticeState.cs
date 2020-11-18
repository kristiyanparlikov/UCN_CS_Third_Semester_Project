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
            throw new NotImplementedException();
        }

        public override void Create(BookingModel booking, DateTime moveInDate, DateTime moveOutDate)
        {
            //notice booking cannot be created
        }

        public override void EnterState(BookingModel booking)
        {
            booking.MoveOutDate = DateTime.UtcNow.AddMonths(3);
        }
    }
}
