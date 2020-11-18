using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelLayer
{
    public class StudentModel : UserModel
    {
        public string DateOfBirth { get; set; }
        public string EducationEndDate { get; set; }
        public string Nationality { get; set; }

        //private Address address;

        public StudentModel() : base() { }

        public StudentModel(string firstName, string lastName, string phoneNumber, string email, string dateOfBirth, string educationEndDate, string nationality) : base(firstName, lastName, phoneNumber, email)
        {
            DateOfBirth = dateOfBirth;
            EducationEndDate = educationEndDate;
            Nationality = nationality;

        }

        

    }
}
