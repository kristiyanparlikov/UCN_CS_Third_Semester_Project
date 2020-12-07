﻿using ModelLayer;
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

        int Add(RoomModel room);

        int Update(RoomModel room);

        void Remove(int id);

        IEnumerable<RoomModel> GetAllAvailable();

        //admin method
        //IEnumerable<BookingModel> GetAllPendingBookingsOnRoom(RoomModel room);
    }
}
