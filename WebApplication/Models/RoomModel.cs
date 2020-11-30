using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class RoomModel
    {
        public int Id { get; set; }

        [Display(Name = "RoomNumber")]
        public int RoomNumber { get; set; }

        [Display(Name = "Floor")]
        public int Floor { get; set; }

        [Display(Name = "Capacity")]
        public int Capacity { get; set; }

        [Display(Name = "Area")]
        public double Area { get; set; }

        [Display(Name = "price")]
        public double Price { get; set; }

        [Display(Name = "isAvailable")]
        public bool isAvailable { get; set; }

        
    }
}