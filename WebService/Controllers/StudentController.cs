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
using WebService.Helper;
using DevOne.Security.Cryptography.BCrypt;

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
                    PhoneNumber = model.PhoneNumber,
                    DateOfBirth = model.DateOfBirth,
                    EducationEndDate = model.EducationEndDate,
                    Nationality = model.Nationality

                };
                //password hash
                string mySalt = BCryptHelper.GenerateSalt();
                var hashedPassword = BCryptHelper.HashPassword(model.Password, mySalt);
                var result = studentHandler.Create(student, hashedPassword);
                if (result != null)
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Problem with database");
                }
            }
            catch (Exception)
            {
                return Ok("Problem in api");
            }
        }
        public HttpResponseMessage Login(LogInUser model)
        {
            //hash incoming password
            string mySalt = BCryptHelper.GenerateSalt();
            string hashedPassword = BCryptHelper.HashPassword(model.Password, mySalt);
            if (studentHandler.VerifyStudentCredentials(model.Email, hashedPassword))
            {
                var user = studentHandler.Get(model.Email);
                return Request.CreateResponse(HttpStatusCode.OK, TokenGenerator.CreateToken(user.Email));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "Email or password is invalid");
            }
        }
    }
}

