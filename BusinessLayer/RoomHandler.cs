using DataAccessLayer;
using DataAccessLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RoomHandler : ICRUD<RoomModel>
    {
        IRoomRepository db = new RoomRepository();

        public void Create(RoomModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RoomModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomModel> GetAll()
        {
            return db.GetAll();
        }

        public bool Update(RoomModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
