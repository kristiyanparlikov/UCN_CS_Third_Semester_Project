using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using DataAccessLayer.Repository;
using System.Configuration;
using ModelLayer;

namespace DataAccessLayer
{
    public class StudentRepository : IRepository<StudentModel>
    {
        private IDbConnection db;

        public StudentRepository()
        {
            this.db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
        }
        public StudentModel Add(StudentModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentModel> Find(Expression<Func<StudentModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public StudentModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public StudentModel Update(StudentModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
