using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WPFClient.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {

        
        HttpClient client = new HttpClient();

        public RegisterView()
        {
            InitializeComponent();
            
        }

        /*Administrator Register
         * TO DO: decide on who decides whats your employee number
         */
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = $"https://localhost:44382//api/Administrator/Register";
            var registerContent = new JObject();
            registerContent.Add("employeeNumber", int.Parse(employeeNumbField.Text));
            registerContent.Add("firstName", fNameField.Text);
            registerContent.Add("lastName", lNameField.Text);
            registerContent.Add("phoneNumber", phoneNumberField.Text);
            registerContent.Add("email", emailField.Text);
            registerContent.Add("password", password.Password);
            HttpContent content = new StringContent(registerContent.ToString(), Encoding.UTF8, "application/json");
            var responseBody = client.PostAsJsonAsync(url, registerContent).Result;
            returnBox.Content = await responseBody.Content.ReadAsStringAsync();
            

        }

    
    }
}
