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
using WPFClient.view_model;

namespace WPFClient.Views
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        HttpClient client = new HttpClient();
        public LogInView()
        {
            InitializeComponent();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindowViewModel vm = MainWindowViewModel.Instance;
            string okMessage = "\"ok\"";
            string url = $"https://localhost:44382/api/Administrator/LogIn";
            var logInContent = new JObject();
            logInContent.Add("Email", emailField.Text);
            logInContent.Add("Password", passwordField.Password);
            HttpContent content = new StringContent(logInContent.ToString(), Encoding.UTF8, "application/json");
            var responseBody = client.PostAsJsonAsync(url, logInContent).Result;
            string response = await responseBody.Content.ReadAsStringAsync();
            if (okMessage.Equals(response))
            {
                AdministratorWindow administratorWindow = new AdministratorWindow();
                administratorWindow.Show();
                vm.CloseAction();
                
            }
            else
            {
                responseBox.Content = response;
            }
            }
    }
}

