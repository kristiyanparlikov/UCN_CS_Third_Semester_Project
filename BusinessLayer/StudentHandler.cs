using DataAccessLayer;
using DataAccessLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace BusinessLayer
{
    public class StudentHandler
    {
        IStudentRepository db = new StudentRepository();

        public StudentModel Create(StudentModel entity, string hashedPassword)
        {
            return db.Add(entity, hashedPassword);
        }

        public int Delete(int id)
        {
            return db.Remove(id);
        }

        public StudentModel Get(int id)
        {
            return db.Find(id);
        }

        public IEnumerable<StudentModel> GetAll()
        {
            return db.GetAll();
        }

        public int Update(StudentModel entity)
        {
            return db.Update(entity);
        }

        public bool VerifyStudentCredentials(string email, string hashedPassword)
        {
            return db.VerifyStudent(email, hashedPassword);
        }
    }
}