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
    public class AdministratorHandler : ICRUD<AdministratorModel>
    {
        IAdministratorRepository db = new AdministratorRepository();
        public void Create(AdministratorModel entity)
        {
            db.Create(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AdministratorModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdministratorModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(AdministratorModel entity)
        {
            throw new NotImplementedException();
        }

        public AdministratorModel adminObjectCreator(string firstName, string lastName, string phoneNumber, string email)
        {
            AdministratorModel admin = new AdministratorModel(firstName, lastName, phoneNumber, email, 1);
            return admin;
        }
    }
}
