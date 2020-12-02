using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RoomsController : Controller
    {
        string Baseurl = "https://localhost:44382/api/";

        static List<RoomModel> rooms = new List<RoomModel>();

        // GET: Rooms with a search filter attribute
        public async Task<ActionResult> Rooms(string searchString)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("Rooms");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var roomsResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    rooms = JsonConvert.DeserializeObject<List<RoomModel>>(roomsResponse);

                    // The rooms array is filtered with the search string if the string is not null, empty or whitespace
                    if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrWhiteSpace(searchString))
                        rooms = rooms.FindAll(room => room.Price.ToString().Equals(searchString));
                }
            }
            //returning the rooms list to view 
            return View(rooms);
        }

        
        public ActionResult Room(int id)
        {
            var room = rooms.Where(r => r.Id == id).FirstOrDefault();

            return View(room);
            //RoomModel room = new RoomModel();
            //using (var client = new HttpClient())
            //{
            //    //Passing service base url
            //    client.BaseAddress = new Uri(Baseurl);

            //    client.DefaultRequestHeaders.Clear();

            //    //Define request data format  
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage Res = await client.GetAsync("Room/" + id);

            //    //Checking the response is successful or not which is sent using HttpClient  
            //    if (Res.IsSuccessStatusCode)
            //    {
            //        //Storing the response details recieved from web api   
            //        var roomResponse = Res.Content.ReadAsStringAsync().Result;

            //        //Deserializing the response recieved from web api and storing into the Employee list  
            //        room = JsonConvert.DeserializeObject<RoomModel>(roomResponse);
            //    }
            //}
            ////returning the rooms list to view 
            //return View(room);
        }

        /*
        [HttpPost]
        public ActionResult Filter(string SelectedPrice, string SelectedCapacity)
        {

            var rawData = (from r in rooms
                           select r);

            var room = from r in rawData
                       select r;

            if (!String.IsNullOrEmpty(SelectedPrice))
            {
                room = room.Where(r => r.Price.ToString().Trim().Equals(SelectedPrice.Trim()));

            }
            if (!String.IsNullOrEmpty(SelectedCapacity))
            {
                room = room.Where(r => r.Price.ToString().Trim().Equals(SelectedCapacity.Trim()));

            }

            var UniquePrice = from r in room
                              group r by r.Price into newGroup
                              where newGroup.Key != null
                              orderby newGroup.Key
                              select new { Price = newGroup.Key };
            ViewBag.UniquePrice = UniquePrice.Select(m => new SelectListItem { Value = m.Price.ToString(), Text = m.Price.ToString() }).ToList();

            var UniqueCapacity = from r in room
                                 group r by r.Capacity into newGroup
                                 where newGroup.Key != null
                                 orderby newGroup.Key
                                 select new { Capacity = newGroup.Key };
            ViewBag.UniqueCapacity = UniqueCapacity.Select(m => new SelectListItem { Value = m.Capacity.ToString(), Text = m.Capacity.ToString() }).ToList();

            ViewBag.SelectedPrice = SelectedPrice;
            ViewBag.SelectedCapacity = SelectedCapacity;

            return View(room);
        */

    }

}    


    
