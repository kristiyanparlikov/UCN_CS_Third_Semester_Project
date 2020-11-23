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
        StudentModel Find(int id);

        List<StudentModel> GetAll();

        StudentModel GetSingleStudent(int id);

        StudentModel Add(StudentModel student);

        bool Update(StudentModel student);

        bool Remove(int id);

    }
}