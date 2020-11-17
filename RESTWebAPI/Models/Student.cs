
using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebAPI.Models
{
    public class Student : User
    {
        public int Id { get; set; } = 0;
        public string DateOfBirth { get; set; } = "";
        public string EducationEndDate { get; set; } = "";
        public string Nationality { get; set; } = "";



        public Student(string firstName, string lastName, string phoneNumber, string email, int id, string dateOfBirth, string educationEndDate, string nationality): base(firstName, lastName, phoneNumber,email)
        {
            Id = id;
            DateOfBirth = dateOfBirth;
            EducationEndDate = educationEndDate;
            Nationality = nationality;
                
        }
    }
}

