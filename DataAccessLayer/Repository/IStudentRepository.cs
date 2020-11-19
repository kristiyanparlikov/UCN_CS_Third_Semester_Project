using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ModelLayer;

namespace DataAccessLayer.Repository
{
    public interface IStudentRepository
    {
        StudentModel Find(int id);

        List<StudentModel> GetAll();

        StudentModel Add(StudentModel student);

        StudentModel Update(StudentModel student);

        void Remove(int id);

    }
}

