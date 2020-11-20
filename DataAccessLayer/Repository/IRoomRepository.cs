using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    interface IRoomRepository
    {
        RoomModel Find(int id);

        List<RoomModel> GetAll();

        void Create(RoomModel admin);

        RoomModel Update(RoomModel booking);

        void Remove(int id);
    }
}
