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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFClient.Models;
using Binding = System.Windows.Data.Binding;
using MessageBox = System.Windows.Forms.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

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

        private async void AproveBooking_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Log off confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using var client = new HttpClient();
                {
                    BookingCast bm = (BookingCast)BookingList.SelectedItem;
                    string url = "https://localhost:44382/api/Bookings/UpdateStatus";
                    var bookingStatusUpdate = new JObject();
                    bookingStatusUpdate.Add("BookingStatus", "Accepted");
                    bookingStatusUpdate.Add("Id", bm.Id);
                    HttpContent content = new StringContent(bookingStatusUpdate.ToString(), Encoding.UTF8, "application/json");
                    var response = client.PostAsync(url, content).Result;
                    responseBox.Content = await response.Content.ReadAsStringAsync();
                }
            }
            GetAllPendingBookings();
        }

    }
}
