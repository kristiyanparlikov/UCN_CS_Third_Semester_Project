using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using UCNThirdSemesterProject.ModelLayer;
using System.Linq;

namespace DataAccessLayer
{
    public class BookingRepository : IBookingRepository
    {
        private IDbConnection db;

        public BookingRepository(string connString)
        {
            this.db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //this.db = new SqlConnection(connString);
        }

        public BookingModel Add(BookingModel booking)
        {
            throw new NotImplementedException();
        }

        public BookingModel Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookingModel> GetAll()
        {
            //return this.db.Query<BookingModel>("SELECT * FROM Bookings").ToList();
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public BookingModel Update(BookingModel booking)
        {
            throw new NotImplementedException();
        }
    }
}
