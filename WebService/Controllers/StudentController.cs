using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebService.Models;
using BusinessLayer;
using ModelLayer;

namespace WebService.Controllers
{
    public class StudentController : ApiController
    {
        StudentHandler studentHandler = new StudentHandler();

        [HttpPost]
        [Route("api/Student/Register")]
        public IHttpActionResult Register(StudentUser model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //student info
                var student = new StudentModel()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    EducationEndDate = model.EducationEndDate,
                    Nationality = model.Nationality

                };
                //password hash
                string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(mySalt, model.Password);

                studentHandler.Create(student, hashedPassword);

                
                
                return Ok("Success");
            }
            catch (Exception)
            {
                return Ok("Something went wrong");
            }
            }
        }
    }
}
