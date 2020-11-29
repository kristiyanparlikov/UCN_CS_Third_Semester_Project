 using DataAccessLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace DataAccessLayer
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        //using ado.net
        public StudentModel Add(StudentModel student, string hashedPassword)
        {
            var query = "INSERT INTO Students (Email, Password, FirstName, LastName, PhoneNumber, DateOfBirth, Nationality, EducationEndDate) ";
            query += "VALUES (@Email, @Password, @FirstName, @LastName, @PhoneNumber, @DateOfBirth, @Nationality, @EducationEndDate) ";
            query += "SELECT CAST (SCOPE_IDENTITY() as int)";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Email", student.Email));
                        cmd.Parameters.Add(new SqlParameter("@Password", hashedPassword));
                        cmd.Parameters.Add(new SqlParameter("@FirstName", student.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
                        cmd.Parameters.Add(new SqlParameter("@DateOfBirth", student.DateOfBirth));
                        cmd.Parameters.Add(new SqlParameter("@Nationality", student.Nationality));
                        cmd.Parameters.Add(new SqlParameter("@EducationEndDate", student.EducationEndDate));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the first statement
                        var id = cmd.ExecuteScalar();
                        student.Id = (int)id;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return student;

        }

        public StudentModel Find(int id)
        {
            string query = "SELECT * FROM Students WHERE Id = @Id";
            StudentModel student = new StudentModel();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                student.Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id"));
                                student.FirstName = dr.GetFieldValue<string>(dr.GetOrdinal("FirstName"));
                                student.LastName = dr.GetFieldValue<string>(dr.GetOrdinal("LastName"));
                                student.PhoneNumber = dr.GetFieldValue<string>(dr.GetOrdinal("PhoneNumber"));
                                student.Email = dr.GetFieldValue<string>(dr.GetOrdinal("Email"));
                                student.DateOfBirth = dr.GetFieldValue<DateTime>(dr.GetOrdinal("DateOfBirth"));
                                student.Nationality = dr.GetFieldValue<string>(dr.GetOrdinal("Nationality"));
                                student.EducationEndDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("EducationEndDate"));
                                return student;
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

        public List<StudentModel> GetAll()
        {
            string query = "SELECT * FROM Students";
            List<StudentModel> students = new List<StudentModel>();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            students.Add(new StudentModel
                            {
                                Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id")),
                                FirstName = dr.GetFieldValue<string>(dr.GetOrdinal("FirstName")),
                                LastName = dr.GetFieldValue<string>(dr.GetOrdinal("LastName")),
                                PhoneNumber = dr.GetFieldValue<string>(dr.GetOrdinal("PhoneNumber")),
                                Email = dr.GetFieldValue<string>(dr.GetOrdinal("Email")),
                                DateOfBirth = dr.GetFieldValue<DateTime>(dr.GetOrdinal("DateOfBirth")),
                                Nationality = dr.GetFieldValue<string>(dr.GetOrdinal("Nationality")),
                                EducationEndDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("EducationEndDate")),

                            });
                        }
                    }
                }
            }
            return students;
        }

        public int Remove(int id)
        {
            string query = "DELETE * FROM Students WHERE Id = '@Id'";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cnn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public int Update(StudentModel student)
        {
            string query = "UPDATE Students SET FirstName = @FirstName ,LastName = @LastName," +
                    "PhoneNumber = @PhoneNumber ,Email = @Email," +
                    "DateOfBirth = @DateOfBirth ,Nationality = @Nationality," +
                    " EducationEndDate = @EducationEndDates WHERE Id = @Id";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))

                    
                {
                    cmd.Parameters.Add(new SqlParameter("@FirstName", student.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@Email", student.Email));
                    cmd.Parameters.Add(new SqlParameter("@DateOfBirth", student.DateOfBirth));
                    cmd.Parameters.Add(new SqlParameter("@Nationality", student.Nationality));
                    cmd.Parameters.Add(new SqlParameter("@EducationEndDate", student.EducationEndDate));

                    cnn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
        public bool VerifyStudent(string email, string hashedPassword)
        {
            string query = "SELECT * FROM Students WHERE Email=@Email AND Password=@Password";

            using(SqlConnection cnn = new SqlConnection(connString))
            {
                using(SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Password", hashedPassword));

                    cnn.Open();

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                        return true;
                    else { return false; }
                }
            }
        }
    }


    //using dapper
    /*
    public StudentModel Add(StudentModel student)
    {
        v
        var sql =
            "INSERT INTO Students (FirstName, LastName, PhoneNumber, Email, DateOfBirth, Nationality, EducationEndDate) VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @DateOfBirth, @Nationality, @EducationEndDate);" +
            "SELECT CAST(SCOPE_INDENTITY() as int)";
        var id = this.db.Query<int>(sql, student).Single();
        student.Id = id;
        return student;
    }

    public StudentModel Find(int id)
    {
        return this.db.Query<StudentModel>("SELECT * FROM Students WHERE Id =@Id", new { id }).SingleOrDefault();
    }

    public StudentModel GetSingleStudent(int id)
    {
        return db.Query<StudentModel>("SELECT[id],[FirstName],[LastName] FROM [Students] WHERE Id =@id", new { Id = id }).SingleOrDefault();
    }

    public List<StudentModel> GetAll()
    {
        return this.db.Query<StudentModel>("SELECT * FROM Students").ToList();
    }

    public bool Remove(int id)
    {
        int rowsAffected = this.db.Execute(@"DELETE FROM [Students] WHERE Id = @Id",
            new { Id = id });

        if (rowsAffected > 0)
        {
            return true;
        }

        return false;
    }

    public bool Update(StudentModel student)
    {
        int rowsAffected = this.db.Execute(
                    "UPDATE [Students] SET [FirstName] = @FirstName ,[LastName] = @LastName," +
                    "[PhoneNumber] = @PhoneNumber ,[Email] = @Email," +
                    "[DateOfBirth] = @DateOfBirth ,[Nationality] = @Nationality," +
                    " [EducationEndDate] = @EducationEndDate WHERE Id = " +
                    student.Id, student);

        if (rowsAffected > 0)
        {
            return true;
        }

        return false;
    }

    */
}