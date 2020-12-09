using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using ModelLayer;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceCore.Controllers
{
    public class RoomsController
    {
        RoomHandler roomHandler = new RoomHandler();

        // GET: api/Rooms
        public IEnumerable<RoomModel> Get()
        {
            return roomHandler.GetAllAvailable();
        }

        // GET: api/Rooms/5
        public RoomModel Get(int id)
        {
            return roomHandler.Get(id);
        }

        //GET: api/Rooms/all
        [Route("api/Rooms/all")]
        public IEnumerable<RoomModel> GetAll()
        {
            return roomHandler.GetAll();
        }

        //WPF admin endpoint
        // POST: api/Rooms
       [HttpPost]
        public ActionResult Post([FromBody] RoomModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int response = roomHandler.Add(model);
                if (response == 1)
                    return Ok("Success");
                else return Ok("Not Ok");
            }
            catch (Exception)
            {
                return Ok("Something went wrong");
            }
        }
       

        // PUT: api/Rooms/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
            roomHandler.Delete(id);
        }



    }
}

