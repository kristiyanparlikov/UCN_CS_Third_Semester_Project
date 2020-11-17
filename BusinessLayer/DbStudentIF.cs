using RESTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface DbStudentIF
    {
        Student GetStudentById(int id);
        List<Student> GetAllStudents();
        int DeleteStudent(int id);
        int CreateStudent(Student student);
        int UpdateStudent(Student student, int id);
    }
}
