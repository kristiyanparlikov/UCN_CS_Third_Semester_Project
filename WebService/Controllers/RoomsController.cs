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
    public class RoomsController : ApiController
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
        public IHttpActionResult Post([FromBody]RoomModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                roomHandler.Add(model);
                return Ok("Success");
            }
            catch (Exception)
            {
                return Ok("Something went wrong");
            }
        }

        // PUT: api/Rooms/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
            roomHandler.Delete(id);
        }

        
        
    }
}
