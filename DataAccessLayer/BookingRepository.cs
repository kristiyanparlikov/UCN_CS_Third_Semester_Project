using DataAccessLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingRepository : IBookingRepository
    {
        //private readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private readonly string connString = "Data Source = hildur.ucn.dk; Initial Catalog = dmaj0919_1081489; User ID = dmaj0919_1081489; Password=Password1!;Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public BookingModel AddAnonymous(BookingModel booking)
        {
            var query = "INSERT INTO Bookings (MoveInDate, MoveOutDate, Status, RoomId) ";
            query += "VALUES (@MoveInDate, @MoveOutDate, @Status, @RoomId) ";
            query += "SELECT CAST (SCOPE_IDENTITY() as int)";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@MoveInDate", booking.MoveInDate));
                        cmd.Parameters.Add(new SqlParameter("@MoveOutDate", booking.MoveOutDate));
                        cmd.Parameters.Add(new SqlParameter("@Status", booking.Status));
                        cmd.Parameters.Add(new SqlParameter("@RoomId", booking.RoomId));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the first statement
                        var id = cmd.ExecuteScalar();
                        booking.Id = (int)id;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return booking;

        }

        public BookingModel Add(BookingModel booking, StudentModel student)
        {
            //SQL statement for Bookings table
            var query1 = "INSERT INTO Bookings (MoveInDate, MoveOutDate, Status) ";
            query1 += "VALUES (@MoveInDate, @MoveOutDate, @Status) ";
            query1 += "SELECT CAST (SCOPE_IDENTITY() as int)";

            //SQL statement for StudentBooking table
            var query2 = "INSERT INTO StudentBooking (StudentId, BookingId) VALUES (@StudentId, @BookingId)";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    //open connection
                    cnn.Open();

                    using (SqlTransaction trn = cnn.BeginTransaction())
                    {
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
                        catch (Exception ex) //catch block for transaction
                        {
                            trn.Rollback();
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return booking;
        }

        public BookingModel Find(int id)
        {
            string query = "SELECT * FROM Bookings WHERE Id = @Id";
            BookingModel booking = new BookingModel();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                booking.Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id"));
                                booking.CreationDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("CreationDate"));
                                booking.MoveInDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("MoveInDate"));
                                booking.MoveOutDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("MoveOutDate"));
                                booking.Status = dr.GetFieldValue<BookingStatus>(dr.GetOrdinal("Status"));
                                return booking;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<BookingModel> GetAll()
        {
            string query = "SELECT * FROM Bookings";
            List<BookingModel> bookings = new List<BookingModel>();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    using(SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            bookings.Add(new BookingModel
                            {
                                Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id")),
                                CreationDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("CreationDate")),
                                MoveInDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("MoveInDate")),
                                MoveOutDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("MoveOutDate")),
                                Status = dr.GetFieldValue<BookingStatus>(dr.GetOrdinal("Status")),
                            });
                        }
                    }
                }
            }
            return bookings;
        }

        public int Remove(int id)
        {
            string query = "DELETE * FROM Bookings WHERE Id = '@Id'";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cnn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public int Update(BookingModel booking)
        {
            string query = "UPDATE Bookings SET MoveInDate = @MoveInDate, MoveOutDate = @MoveOutDate, Status = @Status WHERE Id = @Id";
            using(SqlConnection cnn = new SqlConnection(connString))
            {
                using(SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@MoveInDate", booking.MoveInDate));
                    cmd.Parameters.Add(new SqlParameter("@MoveOutDate", booking.MoveOutDate));
                    cmd.Parameters.Add(new SqlParameter("@Status", booking.Status));
                    cmd.Parameters.Add(new SqlParameter("@Id", booking.Id));

                    cnn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public IEnumerable<BookingModel> GetAllBookingsOfStatus(int status)
        {
            string query = "SELECT * FROM Bookings WHERE Status = @Status";
            List<BookingModel> bookings = new List<BookingModel>();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Status", status));
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            bookings.Add(new BookingModel
                            {
                                Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id")),
                                RoomId = dr.GetFieldValue<int>(dr.GetOrdinal("RoomId")),
                                CreationDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("CreationDate")),
                                MoveInDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("MoveInDate")),
                                MoveOutDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("MoveOutDate")),
                                Status = (BookingStatus)status,
                            });
                        }
                    }
                }
            }
            return bookings;
        }

        public int changeBookingStatus(BookingStatus bookingStatus, int id)
        {
            int rowsAffected = 0;
            string query = "UPDATE Bookings SET Status =@Status WHERE Id =@Id";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                int pending = 0;
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    if (bookingStatus == BookingStatus.Accepted)
                    {
                        cmd.Parameters.Add(new SqlParameter("@Status", 1));
                    }
                    if (bookingStatus == BookingStatus.Cancelled)
                    {
                        cmd.Parameters.Add(new SqlParameter("@Status", 2));
                    }
                    if (bookingStatus == BookingStatus.Living)
                    {
                        cmd.Parameters.Add(new SqlParameter("@Status", 3));
                    }
                    if (bookingStatus == BookingStatus.Pending)
                    {
                        cmd.Parameters.Add(new SqlParameter("@Status", pending));
                    }
                    cnn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public int getBookingStatus(int id)
        {
            int status = -1;
            string query = "SELECT Status FROM Bookings WHERE Id = @Id";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    cnn.Open();
                    var response = cmd.ExecuteScalar();
                    if (response != null)
                        status = Convert.ToInt32(response);
                }
            }
            return status;
        }
    }
}
