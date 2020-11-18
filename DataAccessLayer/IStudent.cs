using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTWebAPI.Models;

namespace DataAccessLayer
{
    interface IStudent
    { 
            Student GetStudentById(int id);
            List<Student> GetAllStudents();
            int DeleteStudent(int id);
            int CreateStudent(Student student);
            int UpdateStudent(Student student, int id);
    }
}
