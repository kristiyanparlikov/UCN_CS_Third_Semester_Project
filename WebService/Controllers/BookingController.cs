using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public void Post([FromBody]BookingModel booking)
        {
            bookingHandler.CreateWithoutStudent(booking);
        }

        // PUT: api/Booking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Booking/5
        public void Delete(int id)
        {
        }
    }
}
