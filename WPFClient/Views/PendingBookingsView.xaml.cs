using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using WPFClient.Models;

namespace WPFClient.Views
{
    /// <summary>
    /// Interaction logic for PendingBookingsView.xaml
    /// </summary>
    public partial class PendingBookingsView : UserControl
    {
        public PendingBookingsView()
        {
            InitializeComponent();
            createTable();
            GetAllPendingBookings();
        }

        public async void GetAllPendingBookings()
        {

            using var client = new HttpClient();
            {
                string url = "https://localhost:44382//api/Bookings/AllPending";
                var response = await client.GetAsync(url);
                var responseJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<BookingCast>>(responseJsonString);
                BookingList.ItemsSource = deserialized;
            }
        }

        private void createTable()
        {
            BookingList.Items.Clear();
            var gridView = new GridView();
            BookingList.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Room Number",
                DisplayMemberBinding = new Binding("RoomId")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Move in date",
                DisplayMemberBinding = new Binding("MoveInDate")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Move out date",
                DisplayMemberBinding = new Binding("MoveOutDate")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Date of creation",
                DisplayMemberBinding = new Binding("CreationDate")
            });
        }

        private void AproveBooking_Clicked(object sender, RoutedEventArgs e)
        {

        }

    }
}
