using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace DataAccessLayer.Repository
{
    public interface IStudentRepository
    {
        StudentModel Find(string email);

        List<StudentModel> GetAll();

        StudentModel Add(StudentModel student, string hashedPassword);

        int Update(StudentModel student);

        int Remove(int id);

        bool VerifyStudent(string email, string hashedPassword);
    }
}