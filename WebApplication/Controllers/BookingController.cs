using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    public class BookingController : Controller
    {

        string Baseurl = "https://localhost:44382/api/";

        static List<BookingModel> bookings = new List<BookingModel>();

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        [Route("{id}")]
        [HttpGet]
        public ActionResult Create(int id)
        {

            return View();
        }

        public ActionResult Message()
        {

            return View();
        }

        // POST: Booking/Create
        [Route("{id}")]
        [HttpPost]
        public async Task<ActionResult> Create(BookingModel booking, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                booking.RoomId = id;

                var json = JsonConvert.SerializeObject(booking);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await client.PostAsync("Booking", data);

                if(Res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Message");
                }
                return RedirectToAction("Rooms");
            }
        }
        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
