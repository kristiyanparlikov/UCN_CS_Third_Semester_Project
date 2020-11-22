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
    }
}
