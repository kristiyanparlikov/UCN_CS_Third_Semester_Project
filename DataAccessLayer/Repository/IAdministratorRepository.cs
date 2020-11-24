using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace DataAccessLayer.Repository
{
    public interface IAdministratorRepository
    {
        AdministratorModel Find(int id);

        List<AdministratorModel> GetAll();
        AdministratorModel GetSingleAdministrator(int id);

        int Add(AdministratorModel administrator);

        bool Update(AdministratorModel administrator);

        bool Remove(int id);
    }
}