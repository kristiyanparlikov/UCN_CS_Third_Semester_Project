using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFClient.Models;
using Newtonsoft;
using Newtonsoft.Json;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;
using Binding = System.Windows.Data.Binding;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WPFClient.Views
{
    /// <summary>
    /// Interaction logic for AllRoomView.xaml
    /// </summary>
    public partial class AllRoomView : UserControl
    {
        string baseUrl = "https://localhost:44382//api/Rooms/";
        public AllRoomView()
        {
            InitializeComponent();  
            createTable();
            GetAllRooms();
        }

        public async void GetAllRooms()
        {
            
            using var client = new HttpClient();
            {
                string url = baseUrl + "all";
                var response = await client.GetAsync(url);
                var responseJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<RoomCast>>(responseJsonString);
                RoomList.ItemsSource = deserialized;
            }
        }

        private void createTable()
        {
            RoomList.Items.Clear();
            var gridView = new GridView();
            RoomList.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Id",
                DisplayMemberBinding = new Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Room Number",
                DisplayMemberBinding = new Binding("RoomNumber")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Description",
                DisplayMemberBinding = new Binding("Description")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Floor",
                DisplayMemberBinding = new Binding("Floor")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Capacity",
                DisplayMemberBinding = new Binding("Capacity")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Area",
                DisplayMemberBinding = new Binding("Area")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Price",
                DisplayMemberBinding = new Binding("Price")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Availability",
                DisplayMemberBinding = new Binding("IsAvailable")
            });
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Do you really want to delete the selected room?","Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RoomCast rm = (RoomCast)RoomList.SelectedItem;
                using var client = new HttpClient();
                {
                    string url = baseUrl + rm.Id;
                    var response = await client.DeleteAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        GetAllRooms();
                    }
                    else
                    {
                        MessageBox.Show(response.ReasonPhrase);
                    }
                }
            }
        }

        private void EditRoom_Clicked(object sender, RoutedEventArgs e)
        {
            EditRoomInfoWindow er = new EditRoomInfoWindow();
            RoomCast rm = (RoomCast)RoomList.SelectedItem;
            er.idField.Content = rm.Id;
            er.roomNumberField.Text = rm.RoomNumber.ToString();
            er.floorField.Text = rm.Floor.ToString();
            er.capacityField.Text = rm.Capacity.ToString();
            er.areaField.Text = rm.Area.ToString();
            er.priceField.Text = rm.Price.ToString();
            er.descriptionField.Text = rm.Description;
            er.Show();
        }
    }
}
