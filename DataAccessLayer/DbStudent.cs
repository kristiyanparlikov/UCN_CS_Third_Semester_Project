using BusinessLayer;
using RESTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbStudent : DbStudentIF
    {

        public Student GetStudentById(int id)
        {
            return null;

        }
        public List<Student> GetAllStudents()
        {
            return null;
        }
        public int DeleteStudent(int id)
        {
            return 0;
        }
        public int CreateStudent(Student student)
        {
            return 0;
        }
        public int UpdateStudent(Student student, int id)
        {
            return 0;
        }
    }
}
