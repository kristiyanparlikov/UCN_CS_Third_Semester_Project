using DataAccessLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using UCNThirdSemesterProject.ModelLayer;
using Dapper;

namespace DataAccessLayer
{
    public class StudentRepository : IStudentRepository
    {
        private IDbConnection db;

        public StudentRepository()
        {
            this.db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public StudentModel Add(StudentModel student)
        {
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


    }
}