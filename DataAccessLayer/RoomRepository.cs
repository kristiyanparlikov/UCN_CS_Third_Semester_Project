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

        private readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public RoomModel Add(RoomModel room)
        {
            var query = "INSERT INTO Rooms (RoomNumber, Floor, Capacity, Area, Price, isAvailable) ";
            query += "VALUES (@RoomNumber, @Floor, @Capacity, @Area, @Price, @isAvailable) ";
            query += "SELECT CAST (SCOPE_IDENTITY() as int)";
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
                        //cmd.Parameters.Add(new SqlParameter("@isAvailable", room.isAvailable));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the first statement
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
                                room.Area = dr.GetFieldValue<float>(dr.GetOrdinal("Area"));
                                room.Price = dr.GetFieldValue<float>(dr.GetOrdinal("Price"));
                                //room.isAvailable = dr.GetFieldValue<>(dr.GetOrdinal("isAvailable"));

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

        public List<RoomModel> GetAll()
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
                                Area = dr.GetFieldValue<float>(dr.GetOrdinal("Area")),
                                Price = dr.GetFieldValue<float>(dr.GetOrdinal("Price")),
                                //isAvailable = dr.GetFieldValue<bit>(dr.GetOrdinal("isAvailable")),
                            });
                        }
                    }
                }
            }
            return rooms;
        }

        public int Remove(int id)
        {
            string query = "DELETE * FROM Rooms WHERE Id = '@Id'";
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

        public int Update(RoomModel room)
        {
            string query = "UPDATE Rooms SET @RoomNumber=RoomNumber, @Floor=Floor, @Capacity=Capacity, @Area=Area, @Price=Price, @isAvailable=isAvailable WHERE Id = @Id";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@RoomNumber", room.RoomNumber));
                    cmd.Parameters.Add(new SqlParameter("@Floor", room.Floor));
                    cmd.Parameters.Add(new SqlParameter("@Capacity", room.Capacity));
                    cmd.Parameters.Add(new SqlParameter("@Area", room.Area));
                    cmd.Parameters.Add(new SqlParameter("@Price", room.Price));
                    cmd.Parameters.Add(new SqlParameter("@isAvailable", room.isAvailable));

                    cnn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public List<RoomModel> retrieveMockData()
        {
            List<RoomModel> rooms = new List<RoomModel>();
            rooms.Add(new RoomModel(1, 101, 1, 1, 50, 2500));
            rooms.Add(new RoomModel(1, 102, 1, 2, 100, 5000));
            rooms.Add(new RoomModel(1, 201, 2, 1, 70, 3000));
            return rooms;
        }
    }
}
