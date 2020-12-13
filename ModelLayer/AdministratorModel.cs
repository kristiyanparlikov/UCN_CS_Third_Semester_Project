using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ModelLayer
{
    public class AdministratorModel : UserModel
    {
        public int EmployeeNumber { get; set; }
        public DateTime modificationDate { get; set; }

        [JsonIgnore]
        public String Password { get; set; }
        //blank constructor
        public AdministratorModel()
        {

        }

        public AdministratorModel(string firstName, string lastName, string phoneNumber, string email, int employeeNumber) : base(firstName, lastName, phoneNumber, email)
        {
            EmployeeNumber = employeeNumber;

        }



    }
}
