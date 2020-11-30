using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Helpers;

namespace WPFClient.view_model
{
    public class RegisterViewModel
    {
        HttpClient client;
        IApiHelper apiHelper;
       

        public RegisterViewModel()
        {
            apiHelper = new ApiHelper();
            
        }

        public async Task<string> registerAdmin(int employeeNumber, string fName, string lName, string phoneNumber, string email)
        {
            string url = $"https://localhost:44302/api/Administrator/Register";
            var registerContent = new JObject();
            registerContent.Add("employeeNumber", employeeNumber);
            registerContent.Add("firstName", fName);
            registerContent.Add("lastName", lName);
            registerContent.Add("phoneNumber", phoneNumber);
            registerContent.Add("email", email);
            HttpContent content = new StringContent(registerContent.ToString(), Encoding.UTF8, "application/json");
            var responseBody = client.PostAsJsonAsync(url, registerContent).Result;
            string response = await responseBody.Content.ReadAsStringAsync();
            return response;
        }
    }
}
