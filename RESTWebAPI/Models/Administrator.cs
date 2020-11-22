using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebAPI.Models
{
    public class Administrator : User
    {
        public string employeeNum { get; set; }
    }
}