﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelLayer
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public UserModel() { }

        public UserModel(int id, string firstName, string lastName, string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;

        }
        public UserModel(string firstName, string lastName, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;

        }



    }
}
