using RESTWebAPI.Models;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLayer;

namespace RESTWebAPI.Controllers
{
    public class AdministratorController : ApiController
    {
        AdministratorHandler adminHandler = new AdministratorHandler();
        List<Administrator> Administrators = new List<Administrator>();

        // GET: api/Administrators
        public List<Administrator> Get()
        {
            return Administrators;
        }



        // GET: api/Administrator/5

        public Administrator Get(int id)
        {
            return Administrators.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Administrator
        [HttpPost]
        [Route("api/Administrator/Register")]
        public IHttpActionResult Post([FromBody] AdministratorModel admin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                adminHandler.Create(admin);
                //Administrators.Add(admin);
                return Ok("Success");
            }
            catch (Exception)
            {
                return Ok("Something went wrong");
            }
        }

        // DELETE: api/Administrator/5
        public void Delete(int id)
        {
            Administrators.RemoveAll(x => x.Id == id);
        }
    }
}

