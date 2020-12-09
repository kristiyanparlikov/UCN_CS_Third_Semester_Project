using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelLayer;
using BC = BCrypt.Net.BCrypt;
using WebServiceCore.Models;

namespace WebServiceCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
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
        public IActionResult Register(AdministratorUser model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int id = adminHandler.checkEmailAvailability(model.Email);
                if (id == 0)
                {
                    //administrator info
                    var administrator = new AdministratorModel()
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        EmployeeNumber = model.employeeNumber,
                    };
                    //password hash
                    string mySalt = BC.GenerateSalt();
                    string hashedPassword = BC.HashPassword(model.Password, mySalt);
                    adminHandler.Create(administrator, hashedPassword);
                    return Ok("Success");
                }
                else return Ok("Email taken");
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

        [HttpPost]
        [Route("api/Administrator/Info")]
        public AdministratorModel getAdministratorInfo([FromBody] StringModel email)
        {
            return adminHandler.getAdministratorInfo(email.email);
        }

        [HttpPost]
        [Route("api/Administrator/LogIn")]
        public IActionResult checkAdminLogIn([FromBody] LogInUser logInUser)
        {
            string realPassword = adminHandler.getAdministratorPassword(logInUser.Email);
            if (realPassword == null)
            {
                return Ok("Incorrect email");
            }
            bool doesPasswordsMatch = BC.Verify(logInUser.Password, realPassword);
            if (doesPasswordsMatch)
            {
                return Ok("ok");
            }
            else return Ok("Incorrect password");
        }


    }
}

