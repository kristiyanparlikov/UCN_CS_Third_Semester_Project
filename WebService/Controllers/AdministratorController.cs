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
using WebService.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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
                int id = adminHandler.CheckEmailAvailability(model.Email);
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
                    string mySalt = BCryptHelper.GenerateSalt();
                    string hashedPassword = BCryptHelper.HashPassword(model.Password, mySalt);
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

        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] LoginRequest login)
        {
            StudentController studentController = new StudentController();
            var loginResponse = new LoginResponse { };

            bool isEmailPasswordValid = false;

            if (login != null)
                isEmailPasswordValid = validateEmailPassword(login.Email, login.Password);

            //if credentials are valid
            if (isEmailPasswordValid)
            {
                //create response object with the user information and the token
                //token
                loginResponse.Token = studentController.createToken(login.Email);
                //user info
                AdministratorModel administrator = adminHandler.GetAdministratorInfo(login.Email);
                loginResponse.Id = administrator.Id;
                loginResponse.Email = administrator.Email;
                loginResponse.FirstName = administrator.FirstName;
                loginResponse.LastName = administrator.LastName;
                loginResponse.PhoneNumber = administrator.PhoneNumber;
                //loginResponse.EmployeeNumber = administrator.EmployeeNumber;
               

                //return the token
                return Ok(loginResponse);
            }
            else
            {
                // if credentials are not valid send unauthorized status code in response
                //loginResponse.responseMsg.StatusCode = HttpStatusCode.Unauthorized;
                //response = ResponseMessage(loginResponse.responseMsg);
                //return response;
                return Unauthorized();
            }
        }

        private bool validateEmailPassword(string email, string password)
        {
            //get the hashed password from the database
            string realPassword = adminHandler.GetAdministratorPassword(email);
            if (realPassword == null)
            {
                return false;
            }
            //check if the hashed password in the database matches with the input password
            bool doesPasswordsMatch = BCryptHelper.CheckPassword(password, realPassword);
            if (doesPasswordsMatch)
            {
                return true;
            }
            else return false;
        }

        // DELETE: api/Administrator/5
        public void Delete(int id)
        {
            Administrators.RemoveAll(x => x.Id == id);
        }

        [HttpPost]
        [Route("api/Administrator/Info")]
        public AdministratorModel GetAdministratorInfo([FromBody] StringModel email)
        {
            return adminHandler.GetAdministratorInfo(email.email);
        }

        [HttpPost]
        [Route("api/Administrator/LogIn")]
        public IHttpActionResult CheckAdminLogIn([FromBody] LoginRequest login)
        {
            string realPassword = adminHandler.GetAdministratorPassword(login.Email);
            if (realPassword == null)
            {
                return Ok("Incorrect email");
            }
            bool doesPasswordsMatch = BCryptHelper.CheckPassword(login.Password, realPassword);
            if (doesPasswordsMatch)
            {
                return Ok("ok");
            }
            else return Ok("Incorrect password");
        }

        public IHttpActionResult updateInfo([FromBody] AdministratorModel admin)
        {
            bool checkForUpdates = adminHandler.CheckModificationDate(admin.modificationDate, admin.Id);
            if (checkForUpdates == false)
                return Ok("Updates Happend, close this window to see changes");
            bool response = adminHandler.Update(admin);
            if (response)
                return Ok("ok");
            return Ok("Something went wrong");
        }

    }
}


