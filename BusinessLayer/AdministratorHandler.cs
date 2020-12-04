using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;
using DataAccessLayer.Repository;

namespace BusinessLayer
{
    public class AdministratorHandler 
    {
        IAdministratorRepository db = new AdministratorRepository();
        public AdministratorModel Create(AdministratorModel entity, string hashedPassword)
        {
            return db.Add(entity, hashedPassword);
        }

        public bool Delete(int id)
        {
            return db.Remove(id);
        }

        public AdministratorModel Get(int id)
        {
            return db.Find(id);
        }

        public IEnumerable<AdministratorModel> GetAll()
        {
            return db.GetAll();
        }

        public bool Update(AdministratorModel administrator)
        {
            return db.Update(administrator);
        }

        public AdministratorModel getAdministratorInfo(string email)
        {
            return db.GetAdministratorInfo(email);
        }
        public string getAdministratorPassword(string email)
        {
            return db.GetAdministratorPassword(email);
        }

        public int checkEmailAvailability(string email)
        {
            return db.checkEmailAvailability(email);
        }
    }
}