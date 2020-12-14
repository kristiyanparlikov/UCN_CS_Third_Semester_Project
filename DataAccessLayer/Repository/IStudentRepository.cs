using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IStudentRepository
    {
        StudentModel FindByEmail(string email);

        StudentModel FindById(int id);

        List<StudentModel> GetAll();

        StudentModel Add(StudentModel student, string hashedPassword);

        bool Update(StudentModel studentModel);

        int Remove(int id);

        bool VerifyStudent(string email, string hashedPassword);

        string GetStudentPassword(string email);
    }
}