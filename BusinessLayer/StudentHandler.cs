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
    class StudentHandler : ICRUD<StudentModel>
    {
        IStudentRepository db = new StudentRepository();

        public void Create(StudentModel entity)
        {
            db.Add(entity);
        }

        public void Delete(int id)
        {
            db.Remove(id);
        }

        public StudentModel Get(int id)
        {
            return db.Find(id);
        }

        public IEnumerable<StudentModel> GetAll()
        {
            return db.GetAll();
        }

        public void Update(StudentModel entity)
        {
            //db.Update(entity.Id);
        }
    }
}
