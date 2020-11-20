using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using UCNThirdSemesterProject.ModelLayer;
using System.Linq;
using Dapper;

namespace DataAccessLayer
{
    public class BookingRepository : IBookingRepository
    {
        private IDbConnection db;

        public BookingRepository()
        {
            this.db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public BookingModel Add(BookingModel booking)
        {
            var sql = 
                "INSERT INTO Bookings (MoveInDate, MoveOutDate, Status) VALUES (@MoveInDate, @MoveOutDate, @Status)" +
                "SELECT CAST (SCOPE_IDENTITY() as int)";
            var id = this.db.Query<int>(sql, booking).Single();
            booking.Id = id;
            return booking;
        }

        public BookingModel Find(int id)
        {
            return this.db.Query<BookingModel>("SELECT * FROM Bookings WHERE Id = @Id", new { id }).SingleOrDefault();
        }

        public List<BookingModel> GetAll()
        {
            return this.db.Query<BookingModel>("SELECT * FROM Bookings").ToList();
        }

        public void Remove(int id)
        {
            this.db.Execute("DELETE FROM Bookings WHERE Id = @Id", new { id });
        }

        public BookingModel Update(BookingModel booking)
        {
            var sql =
                "UPDATE  Bookings " +
                "SET MoveInDate = @MoveInDate, " +
                "    MoveOutDate = @MoveOutDate, " +
                "    Status = @Status " +
                "WHERE Id = @Id";
            this.db.Execute(sql, booking);
            return booking;
        }

    }
}
