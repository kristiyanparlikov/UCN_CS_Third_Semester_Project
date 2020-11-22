using ModelLayer.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCNThirdSemesterProject.ModelLayer
{
    public class BookingModel
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set;  }

        public DateTime MoveInDate { get; set; }

        public DateTime MoveOutDate { get; set; }

        public string Status { get; set; }

        public int roomId { get; set; }

        private BookingState currentState;

        public BookingModel()
        {
            TransitionToState(new NewState());
        }

        public void TransitionToState(BookingState state)
        {
            currentState = state;
            currentState.EnterState(this);
        }

        public void CreateBooking(DateTime moveInDate, DateTime moveOutDate)
        {
            currentState.Create(this, moveInDate, moveOutDate);
        }

        public void Cancel()
        {
            currentState.Cancel(this);
        }

        public void Accept()
        {
            currentState.Accept(this);
        }
    }

}
