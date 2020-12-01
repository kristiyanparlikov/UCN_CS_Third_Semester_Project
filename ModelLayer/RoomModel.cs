using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public double Area { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; } = true;

        List<BookingModel> bookings;

        public RoomModel(int roomNumber, int floor, int capacity, double area, double price, bool isAvailable)
        {
            RoomNumber = roomNumber;
            Floor = floor;
            Capacity = capacity;
            Area = area;
            Price = price;
            IsAvailable = isAvailable;
        }

        public RoomModel(int id, int roomNumber, int floor, int capacity, double area, double price, bool isAvailable)
        {
            Id = id;
            RoomNumber = roomNumber;
            Floor = floor;
            Capacity = capacity;
            Area = area;
            Price = price;
            IsAvailable = isAvailable;
        }

        public RoomModel(int roomNumber, int floor, int capacity, double area, double price)
        {
            RoomNumber = roomNumber;
            Floor = floor;
            Capacity = capacity;
            Area = area;
            Price = price;
        }

        public RoomModel(int id, int roomNumber, int floor, int capacity, double area, double price)
        {
            Id = id;
            RoomNumber = roomNumber;
            Floor = floor;
            Capacity = capacity;
            Area = area;
            Price = price;
        }

        public RoomModel()
        {
            
        }
    }
}
