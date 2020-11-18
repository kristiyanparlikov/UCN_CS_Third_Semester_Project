using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    class AddressModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public AddressModel()
        {

        }

        public AddressModel(int id, string street, string streetNumber, string city, string postalCode, string country)
        {
            Id = id;
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public AddressModel(string street, string streetNumber, string city, string postalCode, string country)
        {
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
