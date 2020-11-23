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
        public AdministratorModel Add(AdministratorModel administrator)
        {
            var sql =
                "INSERT INTO Administrators (FirstName, LastName, PhoneNumber, Email, EmployeeNumber) VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @EmployeeNumber);" +
                "SELECT CAST(SCOPE_INDENTITY() as int)";
            var id = this.db.Query<int>(sql, administrator).Single();
            administrator.Id = id;
            return administrator;
        }

        public AdministratorModel Find(int id)
        {
            return this.db.Query<AdministratorModel>("SELECT * FROM Administrators WHERE Id =@Id", new { id }).SingleOrDefault();
        }

        public AdministratorModel GetSingleAdministrator(int id)
        {
            return db.Query<AdministratorModel>("SELECT[id],[FirstName],[LastName] FROM [Administrators] WHERE Id =@id", new { Id = id }).SingleOrDefault();
        }

        public List<AdministratorModel> GetAll()
        {
            return this.db.Query<AdministratorModel>("SELECT * FROM Administrators").ToList();
        }

        public bool Remove(int id)
        {
            int rowsAffected = this.db.Execute(@"DELETE FROM [Administrators] WHERE Id = @Id",
                new { Id = id });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(AdministratorModel administrator)
        {
            int rowsAffected = this.db.Execute(
                        "UPDATE [Students] SET [FirstName] = @FirstName ,[LastName] = @LastName," +
                        "[PhoneNumber] = @PhoneNumber ,[Email] = @Email," +
                        "[EmployeeNumber] = @EmployeeNumber  WHERE Id = " +
                        administrator.Id, administrator);

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}