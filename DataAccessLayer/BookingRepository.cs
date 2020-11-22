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
using ModelLayer;

namespace DataAccessLayer
{
    public class BookingRepository : IBookingRepository
    {
        
        private IDbConnection db;

        public BookingRepository()
        {
            this.db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        //using dapper
        public BookingModel Add(BookingModel booking)
        {
            var sql = 
                "INSERT INTO Bookings (MoveInDate, MoveOutDate, Status) VALUES (@MoveInDate, @MoveOutDate, @Status)" +
                "SELECT CAST (SCOPE_IDENTITY() as int)";
            var id = this.db.Query<int>(sql, booking).Single();
            booking.Id = id;
            return booking;
        }

        //using ado.net
        public BookingModel AddFull(BookingModel booking, StudentModel student)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                //Booking table
                var query1 = "INSERT INTO Bookings (MoveInDate, MoveOutDate, Status) VALUES (@MoveInDate, @MoveOutDate, @Status)" +
                "SELECT CAST (SCOPE_IDENTITY() as int)";
                using (SqlCommand cmd1 = new SqlCommand(query1, con))
                {
                    // add parameters and their values
                    cmd1.Parameters.AddWithValue("@MoveInDate", booking.MoveInDate);
                    cmd1.Parameters.AddWithValue("@MoveOutDate", booking.MoveOutDate);
                    cmd1.Parameters.AddWithValue("@Status", booking.Status);

                    // open connection, execute command and close connection
                    con.Open();
                    var id = cmd1.ExecuteScalar();
                    con.Close();
                    booking.Id = (int)id;
                }
                
                //StudentBooking table
                var query2 = "INSERT INTO StudentBooking (StudentId, BookingId) VALUES (@StudentId, @BookingId)";

                using (SqlCommand cmd2 = new SqlCommand(query2, con))
                {
                    // add parameters and their values
                    cmd2.Parameters.AddWithValue("@StudentId", student.Id);
                    cmd2.Parameters.AddWithValue("@BookingId", booking.Id);

                    // open connection, execute command and close connection
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
                return booking;
            }
        }

        //using dapper
        public BookingModel Find(int id)
        {
            return this.db.Query<BookingModel>("SELECT * FROM Bookings WHERE Id = @Id", new { id }).SingleOrDefault();
        }

        //using dapper
        public List<BookingModel> GetAll()
        {
            return this.db.Query<BookingModel>("SELECT * FROM Bookings").ToList();
        }

        //using dapper
        public void Remove(int id)
        {
            this.db.Execute("DELETE FROM Bookings WHERE Id = @Id", new { id });
        }

        //using dapper
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
