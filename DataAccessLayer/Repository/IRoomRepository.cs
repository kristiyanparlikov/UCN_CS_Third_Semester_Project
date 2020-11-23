using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IRoomRepository
    {
        RoomModel Find(int id);

        List<RoomModel> GetAll();

        void Create(RoomModel admin);

        bool Update(RoomModel booking);

        bool Remove(int id);
    }
}
