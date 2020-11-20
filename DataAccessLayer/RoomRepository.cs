using DataAccessLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomRepository : IRoomRepository
    {
        public void Create(RoomModel admin)
        {
            throw new NotImplementedException();
        }

        public RoomModel Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoomModel> GetAll()
        {
            return retrieveMockData();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public RoomModel Update(RoomModel booking)
        {
            throw new NotImplementedException();
        }

        public List<RoomModel> retrieveMockData()
        {
            List<RoomModel> rooms = new List<RoomModel>();
            rooms.Add(new RoomModel { Id = 1, RoomNumber = 101, Floor = 1, Capacity = 1, Size = 50, Price = 2500 });
            rooms.Add(new RoomModel { Id = 1, RoomNumber = 102, Floor = 1, Capacity = 2, Size = 100, Price = 5000 });
            rooms.Add(new RoomModel { Id = 1, RoomNumber = 201, Floor = 2, Capacity = 1, Size = 70, Price = 3000 });
            return rooms;        
        }
    }
}
