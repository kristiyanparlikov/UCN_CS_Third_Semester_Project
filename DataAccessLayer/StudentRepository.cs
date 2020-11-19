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

        public StudentRepository(string connString)
        {
            this.db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //this.db = new SqlConnection(connString);       
        }

        public StudentModel Add(StudentModel student)
        {
            var sql =
                "INSERT INTO Student (FirstName, LastName, PhoneNumber, Email, DateOfBirth, Nationality, EducationEndDate) VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @DateOfBirth, @Nationality, @EducationEndDate);" +
                "SELECT CAST(SCOPE_INDENTITY() as int";
            var id = this.db.Query<int>(sql, student).Single();
            student.Id = id;
            return student;
        }

        public StudentModel Find(int id)
        {
            return this.db.Query<StudentModel>("SELECT * FROM Students WHERE Id =@Id", new { id }).SingleOrDefault();
        }

        public List<StudentModel> GetAll()
        {
            return this.db.Query<StudentModel>("SELECT * FROM Students").ToList();
        }

        public void Remove(int id)
        {
            this.db.Execute("DELETE FROM Students WHERE Id=@Id", new { Id = id });
        }

        public StudentModel Update(StudentModel student)
        {
            var sql =
                 "UPDATE Students " +
                 "SET FirstName = @FirstName, " +
                 "LastName = @LastName, " +
                 "PhoneNumber = @PhoneNumber, " +
                 "Email = @Email, " +
                 "DateOfBirth = @DateOfBirth, " +
                 "Nationality = @Nationality " +
                 "EducationEndDate = @EducationEndDate, " +
                 "WHERE Id = @Id";
            this.db.Execute(sql, student);
            return student;
        }
    }
}
