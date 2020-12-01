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

        RoomModel Add(RoomModel room);

        int Update(RoomModel room);

        int Remove(int id);

        IEnumerable<RoomModel> GetAllAvailable();
    }
}
