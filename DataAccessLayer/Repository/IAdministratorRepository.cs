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
        AdministratorModel Add(AdministratorModel administrator, string hashedPassword);
        AdministratorModel Find(int id);
        List<AdministratorModel> GetAll();
        AdministratorModel GetSingleAdministrator(int id);
        bool Update(AdministratorModel administrator);
        bool Remove(int id);
        AdministratorModel GetAdministratorInfo(string email);
        string GetAdministratorPassword(string email);
        int checkEmailAvailability(string email);
    }
}