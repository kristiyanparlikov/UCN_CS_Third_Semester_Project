using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFClient.view_model;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
        }

        private void CreateRoom_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateRoomViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AllRoomViewModel();
        }
    }
}
