
using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebAPI.Models
{
    public class Student : User
    {
        public string DateOfBirth { get; set; }
        public string EducationEndDate { get; set; }
        public string Nationality { get; set; } 



        public Student(int id, string firstName, string lastName, string phoneNumber, string email, string dateOfBirth, string educationEndDate, string nationality): base(id, firstName, lastName, phoneNumber,email)
        {
            DateOfBirth = dateOfBirth;
            EducationEndDate = educationEndDate;
            Nationality = nationality;
                
        }
    }
}

