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

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(RoomModel booking)
        {
            throw new NotImplementedException();
        }

        public List<RoomModel> retrieveMockData()
        {
            List<RoomModel> rooms = new List<RoomModel>();
            rooms.Add(new RoomModel(1, 101, 1, 1, 50, 2500));
            rooms.Add(new RoomModel(1, 102, 1, 2, 100, 5000));
            rooms.Add(new RoomModel(1, 201, 2, 1, 70, 3000));
            return rooms;
        }
    }
}
