using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace ModelLayer.Booking
{
    public class CancelledState : BookingState
    {
        private string reasonCancelled;

        public CancelledState(string reason)
        {
            reasonCancelled = reason;
        }

        public override void Accept(BookingModel booking)
        {
            //cancelled booking cannot be accepted
        }

        public override void Cancel(BookingModel booking)
        {
            //cancelled booking cannot be cancelled
        }

        public override void Create(BookingModel booking, DateTime moveInDate, DateTime moveOutDate)
        {
            //cancelled booking cannot be created
        }

        public override void EnterState(BookingModel booking)
        {
            //show the reason for being cancelled
        }
    }
}
