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
    /// Interaction logic for ApprovedBookingsView.xaml
    /// </summary>
    public partial class ApprovedBookingsView : UserControl
    {
        public ApprovedBookingsView()
        {
            InitializeComponent();
            createTable();
            GetAllApprovedBookings();
        }

        public async void GetAllApprovedBookings()
        {

            using var client = new HttpClient();
            {
                string url = "https://localhost:44382//api/Bookings/AllOfStatus?status=1"; 
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

        private async void CancelBooking_Clicked(object sender, RoutedEventArgs e)
        {
            string okMessage = "\"ok\"";
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Booking cancelation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using var client = new HttpClient();
                {
                    BookingCast bm = (BookingCast)BookingList.SelectedItem;
                    string url = "https://localhost:44382/api/Bookings/CheckStatus";
                    var statusCheck = new JObject();
                    statusCheck.Add("BookingStatus", "Accepted");
                    statusCheck.Add("Id", bm.Id);
                    HttpContent statusCheckContent = new StringContent(statusCheck.ToString(), Encoding.UTF8, "application/json");
                    var statusCheckResponse = client.PostAsync(url, statusCheckContent).Result;
                    string readableResponse = await statusCheckResponse.Content.ReadAsStringAsync();
                    if (okMessage.Equals(readableResponse))
                    {
                        string uri = "https://localhost:44382/api/Bookings/UpdateStatus";
                        var bookingStatusUpdate = new JObject();
                        bookingStatusUpdate.Add("BookingStatus", "Cancelled");
                        bookingStatusUpdate.Add("Id", bm.Id);
                        HttpContent content = new StringContent(bookingStatusUpdate.ToString(), Encoding.UTF8, "application/json");
                        var response = client.PostAsync(uri, content).Result;
                        responseBox.Content = await response.Content.ReadAsStringAsync();
                    }
                    else responseBox.Content = readableResponse;
                }
            }
            GetAllApprovedBookings();
        }

        private async void MoveToPending_Clicked(object sender, RoutedEventArgs e)
        {
            string okMessage = "\"ok\"";
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Booking cancelation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                using var client = new HttpClient();
                {
                    BookingCast bm = (BookingCast)BookingList.SelectedItem;
                    string url = "https://localhost:44382/api/Bookings/CheckStatus";
                    var statusCheck = new JObject();
                    statusCheck.Add("BookingStatus", "Accepted");
                    statusCheck.Add("Id", bm.Id);
                    HttpContent statusCheckContent = new StringContent(statusCheck.ToString(), Encoding.UTF8, "application/json");
                    var statusCheckResponse = client.PostAsync(url, statusCheckContent).Result;
                    string readableResponse = await statusCheckResponse.Content.ReadAsStringAsync();
                    if (okMessage.Equals(readableResponse))
                    {
                        string uri = "https://localhost:44382/api/Bookings/UpdateStatus";
                        var bookingStatusUpdate = new JObject();
                        bookingStatusUpdate.Add("BookingStatus", "Pending");
                        bookingStatusUpdate.Add("Id", bm.Id);
                        HttpContent content = new StringContent(bookingStatusUpdate.ToString(), Encoding.UTF8, "application/json");
                        var response = client.PostAsync(uri, content).Result;
                        responseBox.Content = await response.Content.ReadAsStringAsync();
                    }
                    else responseBox.Content = readableResponse;
                }
            }
            GetAllApprovedBookings();
        }

    }
}