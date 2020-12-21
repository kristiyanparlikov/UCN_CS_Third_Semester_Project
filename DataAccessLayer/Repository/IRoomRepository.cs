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

        IEnumerable<RoomModel> GetAll();

        RoomModel Add(RoomModel room);

        int Update(RoomModel room);

        void Remove(int id);

        IEnumerable<RoomModel> GetAllAvailable();

        bool CheckDateOfModification(DateTime dateTime, int id);

        void ChangeRoomAvailability(int roomId, bool available);

        //admin method
        //IEnumerable<BookingModel> GetAllPendingBookingsOnRoom(RoomModel room);
    }
}
