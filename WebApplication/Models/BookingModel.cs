using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class BookingModel
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        [Display(Name = "Move in date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime MoveInDate { get; set; }

        [Display(Name = "Move out date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime MoveOutDate { get; set; }

        public BookingStatus Status { get; set; }

        public int RoomId { get; set; }
    }

    public enum BookingStatus
    {
        New = 0,
        Pending = 1,
        Accepted = 2,
        Cancelled = 3,
        Living = 4
    }
}