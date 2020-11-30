using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using Newtonsoft;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        static IList<RoomModel> roomList = new List<RoomModel>{
                new RoomModel() { RoomNumber=1, Floor=1,Capacity=2,Area=50,Price=3000, isAvailable=true  } ,
                new RoomModel() {  RoomNumber=2, Floor=1,Capacity=1,Area=28,Price=1500, isAvailable=false} ,
                new RoomModel() { RoomNumber=3, Floor=2,Capacity=1,Area=38,Price=2500, isAvailable=true } ,
                
            };
    
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Room()
        {
            ViewBag.Message = "Your application description page.";


            return View(roomList);
        }

        public ActionResult Booking()
        {
            ViewBag.Message = "Your contact page.";

            return View();

        }

        public ActionResult Register()
        {

            return View();

        }

        public ActionResult Login()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(StudentRegisterModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44382/api/");
                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //HTTP POST
                var postTask = client.PostAsync("Student/Register", data);

                
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(StudentLoginModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44382/api/");

                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("Student/Login", data);
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                //HttpResponseMessage login = client.PostAsync("/token", new FormUrlEncodedContent(new Dictionary<string, string> { { "grant_type", "password" }, { "username", model.Email }, { "password", model.Password } })).Result;
                //if (login.StatusCode == HttpStatusCode.OK)
                //{
                //    var result = login.Content.ReadAsStringAsync().Result;
                //    Dictionary<string, string> tokenDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                //    string accessToken = tokenDictionary["access_token"];

                //    return RedirectToAction("Index");
                // }

            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(model);
        }
    }
}