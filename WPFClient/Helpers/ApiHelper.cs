using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Helpers
{
    public class ApiHelper
    {
        public HttpClient apiClient { get; set; }

        public ApiHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

       /* public async Task<LogInUser> logInAuthenticate(string email, string password)
        {
            var data = new LogInUser()
            {
                Email = email,
                Password = password
            };

            using (HttpResponseMessage response = await apiClient.PostAsync("api/Administrator/LogIn", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }*/
        }
    }

