using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class BookingModel
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime MoveInDate { get; set; }

        public DateTime MoveOutDate { get; set; }

        public BookingStatus Status { get; set; }

        public int RoomId { get; set; }

        public int UserId { get; set; }

        public BookingModel()
        {

        }

        public BookingModel(int id, DateTime creationDate, DateTime moveInDate, BookingStatus status, int userId)
        {
            Id = id;
            CreationDate = creationDate;
            MoveInDate = moveInDate;
            Status = status;
            UserId = userId;
        }

        public BookingModel(int id, DateTime creationDate, DateTime moveInDate, BookingStatus status, int roomId, int userId)
        {
            Id = id;
            CreationDate = creationDate;
            MoveInDate = moveInDate;
            Status = status;
            RoomId = roomId;
            UserId = userId;
        }

        public BookingModel(DateTime creationDate, DateTime moveInDate, BookingStatus status, int userId)
        {
            CreationDate = creationDate;
            MoveInDate = moveInDate;
            Status = status;
            UserId = userId;
        }

        public BookingModel(DateTime creationDate, DateTime moveInDate, BookingStatus status, int roomId, int userId)
        {
            CreationDate = creationDate;
            MoveInDate = moveInDate;
            Status = status;
            RoomId = roomId;
            UserId = userId;
        }


    }

}
