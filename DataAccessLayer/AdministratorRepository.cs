using System;
using ModelLayer;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private IDbConnection db;

        public AdministratorRepository() 
        {
            this.db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        public void Create(AdministratorModel admin)
        {
            using (db)
            {
                var p = new DynamicParameters();
                p.Add("@EmployeeNumber", admin.EmployeeNumber);
                p.Add("@FName", admin.FirstName);
                p.Add("@LName", admin.LastName);
                p.Add("@PhoneNumber", admin.PhoneNumber);
                p.Add("@Email", admin.Email);
                string sql = "INSERT INTO Administrator VALUES @EmployeeNumber, @FName, @LName, @PhoneNumber,@Email";
                db.Open();
                db.Execute(sql, p);
            }
            }

        public AdministratorModel Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<AdministratorModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public AdministratorModel Update(AdministratorModel booking)
        {
            throw new NotImplementedException();
        }
    }
    }


