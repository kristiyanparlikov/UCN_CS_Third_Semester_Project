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
        public string Description { get; set; }
        public bool IsAvailable { get; set; } = true;


        List<BookingModel> bookings;

        public RoomModel(int roomNumber, int floor, int capacity, double area, double price,string description, bool isAvailable)
        {
            RoomNumber = roomNumber;
            Floor = floor;
            Capacity = capacity;
            Area = area;
            Price = price;
            Description = description;
            IsAvailable = isAvailable;
        }

        public RoomModel(int id, int roomNumber, int floor, int capacity, double area, double price,string description, bool isAvailable)
        {
            Id = id;
            RoomNumber = roomNumber;
            Floor = floor;
            Capacity = capacity;
            Area = area;
            Price = price;
            Description = description;
            IsAvailable = isAvailable;
        }

        public RoomModel(int roomNumber, int floor, int capacity, double area, double price, string description)
        {
            RoomNumber = roomNumber;
            Floor = floor;
            Capacity = capacity;
            Area = area;
            Price = price;
            Description = description;
        }

        public RoomModel(int id, int roomNumber, int floor, int capacity, double area, double price, string description)
        {
            Id = id;
            RoomNumber = roomNumber;
            Floor = floor;
            Capacity = capacity;
            Area = area;
            Price = price;
            Description = description;
        }

        public RoomModel()
        {
            
        }
    }
}
