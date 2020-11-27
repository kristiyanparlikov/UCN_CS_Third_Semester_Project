using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using BusinessLayer;
using ModelLayer;

namespace WPFClient.views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        HttpClient client = new HttpClient();
        AdministratorHandler administratorHandler = new AdministratorHandler();

        public RegisterView()
        {
            InitializeComponent();
            
        }

        /*Administrator Register
         * TO DO: decide on who decides whats your employee number
         */
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AdministratorModel admin = administratorHandler.adminObjectCreator(fName.Text, lName.Text, phoneNumber.Text, email.Text);
            String url = $"https://localhost:44302/api/Administrator/Register/{admin}";
            String responseBody = await client.GetStringAsync(url);
            returnBox.Content = JsonConvert.DeserializeObject<String>(responseBody);
           

        }
    }
}
