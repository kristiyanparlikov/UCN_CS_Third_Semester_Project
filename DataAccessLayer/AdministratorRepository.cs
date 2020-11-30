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
        private readonly string connString = "Data Source = hildur.ucn.dk; Initial Catalog = dmaj0919_1081489; User ID = dmaj0919_1081489; Password=Password1!;Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public AdministratorRepository()
        {


        }
        public AdministratorModel Add(AdministratorModel administrator, string hashedPassword)
        {
            var sql = "INSERT INTO Administrators (Email, Password, FirstName, LastName, PhoneNumber,  EmployeeNumber) " +
                "VALUES (@Email, @Password, @FirstName, @LastName, @PhoneNumber,  @EmployeeNumber) " +
                "SELECT CAST (SCOPE_IDENTITY() as int)";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Email", administrator.Email));
                        cmd.Parameters.Add(new SqlParameter("@Password", hashedPassword));
                        cmd.Parameters.Add(new SqlParameter("@FirstName", administrator.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", administrator.LastName));
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", administrator.PhoneNumber));
                        cmd.Parameters.Add(new SqlParameter("@EmployeeNumber", administrator.EmployeeNumber));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the first statement
                        var id = cmd.ExecuteScalar();
                        administrator.Id = (int)id;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        public string GetAdministratorPassword(string email)
        {
            string password = null;
            var sql = "SELECT [Password] FROM [Administrator] WHERE Email =@Email ";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Email", email));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the first statement
                        password = (string)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return password;
        }
    }
}
        
    

