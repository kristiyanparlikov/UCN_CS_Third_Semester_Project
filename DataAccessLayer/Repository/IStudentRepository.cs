using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ModelLayer;

namespace DataAccessLayer.Repository
{
    public interface IStudentRepository
    {
        StudentModel Add(StudentModel entity);

        StudentModel Update(StudentModel entity);

        StudentModel Get(int id);

        IEnumerable<StudentModel> GetAll();

        IEnumerable<StudentModel> Find(Expression<Func<StudentModel, bool>> predicate);

        bool Remove(int id);
    }
}

