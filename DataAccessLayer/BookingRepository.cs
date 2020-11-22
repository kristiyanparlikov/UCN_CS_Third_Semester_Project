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
        public BookingModel AddAnonymous(BookingModel booking)
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
            //SQL statement for Bookings table
            var query1 = "INSERT INTO Bookings (MoveInDate, MoveOutDate, Status) ";
            query1 += "VALUES (@MoveInDate, @MoveOutDate, @Status) ";
            query1 += "SELECT CAST (SCOPE_IDENTITY() as int)";

            //SQL statement for StudentBooking table
            var query2 = "INSERT INTO StudentBooking (StudentId, BookingId) VALUES (@StudentId, @BookingId)";
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    //open connection
                    cnn.Open();

                    using (SqlTransaction trn = cnn.BeginTransaction()) {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(query1, cnn))
                            {
                                // Add the transaction to the command object
                                cmd.Transaction = trn;

                                // Create input parameters
                                cmd.Parameters.Add(new SqlParameter("@MoveInDate", booking.MoveInDate));
                                cmd.Parameters.Add(new SqlParameter("@MoveOutDate", booking.MoveOutDate));
                                cmd.Parameters.Add(new SqlParameter("@Status", booking.Status));

                                // Set CommandType
                                cmd.CommandType = CommandType.Text;

                                // Execute the first statement
                                var id = cmd.ExecuteScalar();
                                booking.Id = (int)id;

                                //***Second statement to execute***

                                // Reset the command text
                                cmd.CommandText = query2;

                                // Clear previous parameters
                                cmd.Parameters.Clear();

                                // Create input parameters 
                                cmd.Parameters.AddWithValue("@StudentId", student.Id);
                                cmd.Parameters.AddWithValue("@BookingId", booking.Id);

                                // Execute the second statement
                                cmd.ExecuteNonQuery();

                                // Finish the transaction
                                trn.Commit();
                            }
                        }
                        catch(Exception ex) //catch block for transaction
                        {
                            trn.Rollback();
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return booking;
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
        public int Remove(int id)
        {
            return this.db.Execute("DELETE FROM Bookings WHERE Id = @Id", new { id });
        }

        //using dapper
        public int Update(BookingModel booking)
        {
            var sql =
                "UPDATE  Bookings " +
                "SET MoveInDate = @MoveInDate, " +
                "    MoveOutDate = @MoveOutDate, " +
                "    Status = @Status " +
                "WHERE Id = @Id";
            return this.db.Execute(sql, booking);
        }

    }
}
