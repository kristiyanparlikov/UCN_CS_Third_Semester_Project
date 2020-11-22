using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace ModelLayer
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public bool isAvailable { get; set; } = true;

        List<BookingModel> bookings;

        public RoomModel(int roomNumber, int floor, int capacity, double size, double price)
        {
            RoomNumber = roomNumber;
            Floor = floor;
            Capacity = capacity;
            Size = size;
            Price = price;
        }

        public RoomModel(int id, int roomNumber, int floor, int capacity, double size, double price)
        {
            Id = id;
            RoomNumber = roomNumber;
            Floor = floor;
            Capacity = capacity;
            Size = size;
            Price = price;
        }
    }
}
