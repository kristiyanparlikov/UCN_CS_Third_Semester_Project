using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IAdministratorRepository
    {
        AdministratorModel Find(int id);

        List<AdministratorModel> GetAll();

        void Create(AdministratorModel admin);

        AdministratorModel Update(AdministratorModel booking);

        void Remove(int id);
    }
}
