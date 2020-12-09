using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelLayer;
using System.Net;
using System.Net.Http;
using WebServiceCore.Models;

namespace WebServiceCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
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

            [Route("api/Bookings/AllPending")]
            public IEnumerable<BookingModel> GetAllPendingBookings()
            {
                return bookingHandler.GetAllPendingBookings();
            }

            [HttpPost]
            [Route("api/Bookings/UpdateStatus")]
            public IActionResult changeBookingStatus([FromBody] BookingStatusUpdateModel bookingStatus)
            {
                int rowsAffected = bookingHandler.changeBookingStatus(bookingStatus.BookingStatus, bookingStatus.Id);
                if (rowsAffected == 1)
                    return Ok("All good");
                if (rowsAffected == 0)
                    return Ok("Booking error");
                return Ok("Wh... What?");
            }
    }
}

