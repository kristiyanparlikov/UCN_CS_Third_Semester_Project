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
    public class RoomRepository : IRoomRepository
    {

        //private readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private readonly string connString = "Data Source = hildur.ucn.dk; Initial Catalog = dmaj0919_1081489; User ID = dmaj0919_1081489; Password=Password1!;Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public RoomModel Add(RoomModel room)
        {
            var query = "INSERT INTO Rooms VALUES (@RoomNumber, @Floor, @Capacity, @Area, @Price, @isAvailable,  @Description) " +
                "SELECT CAST (SCOPE_IDENTITY() as int)"; 
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@RoomNumber", room.RoomNumber));
                        cmd.Parameters.Add(new SqlParameter("@Floor", room.Floor));
                        cmd.Parameters.Add(new SqlParameter("@Capacity", room.Capacity));
                        cmd.Parameters.Add(new SqlParameter("@Area", room.Area));
                        cmd.Parameters.Add(new SqlParameter("@Price", room.Price)); 
                        cmd.Parameters.Add(new SqlParameter("@isAvailable", room.IsAvailable));
                        cmd.Parameters.Add(new SqlParameter("@Description", room.Description));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the statement
                        var id = cmd.ExecuteScalar();
                        room.Id = (int)id;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return room;
        }
        

        public RoomModel Find(int id)
        {
            string query = "SELECT * FROM Rooms WHERE Id = @Id";
            RoomModel room = new RoomModel();
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
                                room.Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id"));
                                room.RoomNumber = dr.GetFieldValue<int>(dr.GetOrdinal("RoomNumber"));
                                room.Floor = dr.GetFieldValue<int>(dr.GetOrdinal("Floor"));
                                room.Capacity = dr.GetFieldValue<int>(dr.GetOrdinal("Capacity"));
                                room.Area = dr.GetFieldValue<double>(dr.GetOrdinal("Area"));
                                room.Price = dr.GetFieldValue<double>(dr.GetOrdinal("Price"));
                                room.Description = dr.GetFieldValue<string>(dr.GetOrdinal("Description"));
                                room.IsAvailable = dr.GetBoolean(dr.GetOrdinal("isAvailable"));

                                return room;
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

        public IEnumerable<RoomModel> GetAll()
        {
            string query = "SELECT * FROM Rooms";
            List<RoomModel> rooms = new List<RoomModel>();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            rooms.Add(new RoomModel
                            {
                                Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id")),
                                RoomNumber = dr.GetFieldValue<int>(dr.GetOrdinal("RoomNumber")),
                                Floor = dr.GetFieldValue<int>(dr.GetOrdinal("Floor")),
                                Capacity = dr.GetFieldValue<int>(dr.GetOrdinal("Capacity")),
                                Area = dr.GetFieldValue<double>(dr.GetOrdinal("Area")),
                                Price = dr.GetFieldValue<double>(dr.GetOrdinal("Price")),
                                Description = dr.GetFieldValue<string>(dr.GetOrdinal("Description")),
                                IsAvailable = dr.GetBoolean(dr.GetOrdinal("isAvailable")),
                            });
                        }
                    }
                    cnn.Close();
                }
            }
            return rooms;
        }

        public void Remove(int id)
        {
            string query = "DELETE FROM Rooms WHERE Id =@Id";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int Update(RoomModel room)
        {
            string query = "UPDATE Rooms SET RoomNumber = @RoomNumber, Floor = @Floor, Capacity = @Capacity, Area = @Area, Price = @Price, isAvailable = @isAvailable, description = @description  WHERE Id = @Id";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", room.Id));
                    cmd.Parameters.Add(new SqlParameter("@RoomNumber", room.RoomNumber));
                    cmd.Parameters.Add(new SqlParameter("@Floor", room.Floor));
                    cmd.Parameters.Add(new SqlParameter("@Capacity", room.Capacity));
                    cmd.Parameters.Add(new SqlParameter("@Area", room.Area));
                    cmd.Parameters.Add(new SqlParameter("@Price", room.Price));
                    cmd.Parameters.Add(new SqlParameter("@isAvailable", room.IsAvailable));
                    cmd.Parameters.Add(new SqlParameter("@description", room.Description));


                    cnn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public List<RoomModel> retrieveMockData()
        {
            List<RoomModel> rooms = new List<RoomModel>();
            rooms.Add(new RoomModel(1, 101, 1, 1, 50, 2500,"hhh"));
            rooms.Add(new RoomModel(1, 102, 1, 2, 100, 5000, "hhh"));
            rooms.Add(new RoomModel(1, 201, 2, 1, 70, 3000, "hhh"));
            return rooms;
        }

        public IEnumerable<RoomModel> GetAllAvailable()
        {
            string query = "SELECT * FROM Rooms WHERE isAvailable=1";
            List<RoomModel> rooms = new List<RoomModel>();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            rooms.Add(new RoomModel
                            {
                                Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id")),
                                RoomNumber = dr.GetFieldValue<int>(dr.GetOrdinal("RoomNumber")),
                                Floor = dr.GetFieldValue<int>(dr.GetOrdinal("Floor")),
                                Capacity = dr.GetFieldValue<int>(dr.GetOrdinal("Capacity")),
                                Area = dr.GetFieldValue<double>(dr.GetOrdinal("Area")),
                                Price = dr.GetFieldValue<double>(dr.GetOrdinal("Price")),
                                Description = dr.GetFieldValue<string>(dr.GetOrdinal("Description")),
                                IsAvailable = dr.GetBoolean(dr.GetOrdinal("IsAvailable")),
                            });
                        }
                    }
                }
            }
            return rooms;
        }
    }
}
