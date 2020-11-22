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

namespace WPFClient.views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        //AdministratorControler adminCtrl;
        public RegisterView()
        {
            InitializeComponent();
            static readonly HttpClient client = new HttpClient();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
           

        }
    }
}
