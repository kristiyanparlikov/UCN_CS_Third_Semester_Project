using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceCore.Models;

namespace WebService.Controllers
{
    public class BookingController : ApiController
    {
        BookingHandler bookingHandler = new BookingHandler();
        // GET: api/Booking
        public IEnumerable<BookingModel> Get()
        {
            return bookingHandler.GetAll();
        }

        // GET: api/Booking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        public void Post([FromBody] BookingModel booking)
        {
            bookingHandler.CreateWithoutStudent(booking);
        }

        // PUT: api/Booking/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Booking/5
        public void Delete(int id)
        {
        }

        [Route("api/Bookings/AllOfStatus")]
        public IEnumerable<BookingModel> GetAllBookingsOfType(int status)
        {
            return bookingHandler.GetAllBookingsOfStatus(status);
        }

        [HttpPost]
        [Route("api/Bookings/UpdateStatus")]
        public IHttpActionResult changeBookingStatus([FromBody] BookingStatusUpdateModel statusUpdate)
        {
            int rowsAffected = bookingHandler.changeBookingStatus(statusUpdate.BookingStatus, statusUpdate.Id);
            if (rowsAffected == 1)
                return Ok("All good");
            if (rowsAffected == 0)
                return Ok("Booking error");
            return Ok("Wh... What?");
        }

        [Route("api/Bookings/CheckStatus")]
        public IHttpActionResult checkBookingStatus([FromBody] BookingStatusUpdateModel statusUpdate)
        {
            int status = bookingHandler.getBookingStatus(statusUpdate.Id);
            int realStatus = -2;
            if (statusUpdate.BookingStatus == BookingStatus.Pending)
            {
                realStatus = 0;
            }
            if (statusUpdate.BookingStatus == BookingStatus.Accepted)
            {
                realStatus = 1;
            }
            if (statusUpdate.BookingStatus == BookingStatus.Cancelled)
            {
                realStatus = 2;
            }
            if (statusUpdate.BookingStatus == BookingStatus.Living)
            {
                realStatus = 3;
            }
            if (realStatus == status)
                return Ok("ok");
            else if (status == 0)
                return Ok("Booking status was changed to pending");
            else if (status == 1)
                return Ok("Booking was already approved");
            else if (status == 2)
                return Ok("Booking was cancelled");
            else if (status == 3)
                return Ok("Booking is already confirmed by student");
            return Ok("Booking does not exist");
        }
    }
}
