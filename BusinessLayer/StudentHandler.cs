using DataAccessLayer;
using DataAccessLayer.Repository;
using ModelLayer;
using System.Collections.Generic;

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

        public StudentModel Get(string email)
        {
            return db.Find(email);
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

        public string GetStudentPassword(string email)
        {
            return db.GetStudentPassword(email);
        }
    }
}