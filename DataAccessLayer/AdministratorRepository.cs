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
            var sql = "UPDATE Administrators SET Email = @Email, FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber WHERE Id = @Id";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", administrator.Id));
                        cmd.Parameters.Add(new SqlParameter("@Email", administrator.Email));
                        cmd.Parameters.Add(new SqlParameter("@FirstName", administrator.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", administrator.LastName));
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", administrator.PhoneNumber));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the first statement
                        var rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public AdministratorModel GetAdministratorInfo(string email)
        {
            string query = "SELECT * FROM Administrators WHERE Email= @Email";
            AdministratorModel admin = new AdministratorModel();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Email", email));

                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                admin.Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id"));
                                admin.Email = dr.GetFieldValue<string>(dr.GetOrdinal("Email"));
                                admin.FirstName = dr.GetFieldValue<string>(dr.GetOrdinal("FirstName"));
                                admin.LastName = dr.GetFieldValue<string>(dr.GetOrdinal("LastName"));
                                admin.PhoneNumber = dr.GetFieldValue<string>(dr.GetOrdinal("PhoneNumber"));
                                admin.EmployeeNumber = Convert.ToInt32(dr.GetFieldValue<string>(dr.GetOrdinal("EmployeeNumber")));
                                admin.modificationDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("ModifiedDate"));
                                return admin;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
            }
            return null;
        }

        public string GetAdministratorPassword(string email)
        {
            string password = null;
            var sql = "SELECT [Password] FROM [Administrators] WHERE Email =@Email ";
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

        public int checkEmailAvailability(string email)
        {
            int id = 0;
            var sql = "SELECT Id FROM Administrators WHERE Email =@Email";
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
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            id = Convert.ToInt32(result);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return id;
        }

        public bool checkDateOfModification(DateTime dateTime, int id)
        {
            DateTime modDate;
            var sql = "SELECT ModifiedDate FROM Administrators WHERE Id = @Id";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Id", id));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the first statement
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            modDate = Convert.ToDateTime(result);
                            if (dateTime == modDate)
                                return true;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
    }

}