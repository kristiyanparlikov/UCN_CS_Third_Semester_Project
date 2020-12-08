using BusinessLayer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebServiceCore.Helpers;
using WebServiceCore.Models;

namespace WebServiceCore.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<StudentModel> GetAll();
        StudentModel GetById(int id);
    }


    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private StudentHandler studentHandler;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            studentHandler = new StudentHandler();
        }

        private List<StudentModel> _users = new List<StudentModel>
        {
            new StudentModel { Id = 1, FirstName = "Test", LastName = "User", Email = "test", Password = "test" }
        };



        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            string realPassword = studentHandler.GetStudentPassword(model.Email);
            if (realPassword == null)
            {
                return null;
            }
            if(BCrypt.Net.BCrypt.Verify(model.Password, realPassword))
            {
                var user = studentHandler.Get(model.Email);

                if (user == null) return null;


                // authentication successful so generate jwt token
                var token = generateJwtToken(user);

                return new AuthenticateResponse(user, token);
            }
            else
            {
                return null;
            }

            

            //var user = _users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            //StudentModel user = studentHandler.Get(model.Email);
            

        }

        public IEnumerable<StudentModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        //helper methods

        private string generateJwtToken(StudentModel user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
