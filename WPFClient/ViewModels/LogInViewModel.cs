using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPFClient.Helpers;

namespace WPFClient.view_model
{
    public class LogInViewModel 
    {
        private string emaill;
        private string password;
        private IApiHelper apiHelper;

        public LogInViewModel()
        {
            apiHelper = new ApiHelper();
        }

        public async Task LogIn()
        {
            try
            {
                var result = await apiHelper.logInAuthenticate(emaill, password);
            }
            catch (Exception ex)
            {
                //handle exception
                throw;
            }
        }
    }
}
