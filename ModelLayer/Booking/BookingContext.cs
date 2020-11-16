﻿using ModelLayer.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCNThirdSemesterProject.ModelLayer
{
    public class BookingContext
    {
        public int BookingId { get; set; }

        public DateTime MadeOn { get; }

        public DateTime MoveInDate { get; set; }

        public DateTime MoveOutDate { get; set; }

        private BookingState currentState;

        public BookingContext()
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
