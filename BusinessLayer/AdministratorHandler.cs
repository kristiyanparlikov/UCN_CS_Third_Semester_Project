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
            db.Add(entity);
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
    }
}