using RESTWebAPI.Models;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLayer;
using DevOne.Security.Cryptography.BCrypt;


namespace WebService.Controllers
{

    public class AdministratorController : ApiController
    {
        AdministratorHandler adminHandler = new AdministratorHandler();
        List<AdministratorModel> Administrators = new List<AdministratorModel>();

        // GET: api/Administrators
        public List<AdministratorModel> Get()
        {
            return Administrators;
        }



        // GET: api/Administrator/5

        public AdministratorModel Get(int id)
        {
            return Administrators.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Administrator
        [HttpPost]
        [Route("api/Administrator/Register")]
        public IHttpActionResult Register(AdministratorUser model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //administrator info
                var administrator = new AdministratorModel()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                };
                //password hash
                string mySalt = BCryptHelper.GenerateSalt();
                string hashedPassword = BCryptHelper.HashPassword(model.Password, mySalt);
                adminHandler.Create(administrator, hashedPassword);
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
    

        
        [HttpGet]
        [Route("api/Administrator/LogIn")]
        public IHttpActionResult checkAdminLogIn(string email, string password)
        {
            string realPassword = adminHandler.getAdministratorPassword(email);
            bool doesPasswordsMatch = BCryptHelper.CheckPassword(password, realPassword);
            if (doesPasswordsMatch)
            {
                return Ok("Log in correct");
            }
            else return Ok("Incorrect password");
        }


    }
}
        
