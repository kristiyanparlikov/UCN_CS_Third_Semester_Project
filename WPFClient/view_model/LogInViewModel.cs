using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFClient.Helpers;

namespace WPFClient.view_model
{
    public class LogInViewModel
    {
        private string email;
        private string password;
        private IApiHelper apiHelper;

        public LogInViewModel()
        {
            
        }

       /* public async Task LogIn(string email, string password)
        {
            try
            {
                var result = await apiHelper.logInAuthenticate(email, password);
            }
            catch (Exception ex)
            {
                //handle exception
                throw;
            }
        }*/
    }
}