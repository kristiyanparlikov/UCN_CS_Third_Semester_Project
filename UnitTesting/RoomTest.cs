using System;
using DataAccessLayer.Repository;
using DataAccessLayer;
using ModelLayer;
using System.Data;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Controllers;
using System.Data.Common;
using System.Collections.Generic;
using WebApplication.Models;
using System.Linq;
using RoomModel = ModelLayer.RoomModel;


namespace UnitTesting
{
    [TestClass]
    public class RoomTest
    {
        private RoomRepository roomDb;
        private readonly string connString = "Data Source = hildur.ucn.dk; Initial Catalog = dmaj0919_1081489; User ID = dmaj0919_1081489; Password=Password1!;Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public RoomTest()
        {
            roomDb = new RoomRepository();
        }
            
        [TestMethod]
        public void CreateRoomTest()
        {
            //Arrange
            RoomModel room = new RoomModel();
            room.RoomNumber = 1;
            room.Price = 1200;
            room.IsAvailable = true;
            room.Floor = 3;
            room.Capacity = 1;
            room.Area = 20;
            room.Description = "furnished";
            //Act
            roomDb.Add(room);
            //Assert
            Assert.IsNotNull(room);
        }       

        [TestMethod]
        public void GetRoomsTest()
        {
            //Arrange
            List<ModelLayer.RoomModel> rooms = (List<ModelLayer.RoomModel>)roomDb.GetAll();
            //Act
            int roomsTotal = 0;
            if (rooms is List<ModelLayer.RoomModel>)
            {
                roomsTotal = rooms.Count;
            }
            //Assert
            Assert.IsTrue(roomsTotal > 0);
        }

        [TestMethod]
        public void GetRoomById()
        {
            //Arrange
            List<ModelLayer.RoomModel> rooms = (List<ModelLayer.RoomModel>)roomDb.GetAll();
            //Act
            int total = rooms.Count;
            int id = rooms[total - 1].Id;
            ModelLayer.RoomModel room = roomDb.Find(id);
            //Assert
            Assert.AreEqual(room.Id, id);
        }

        [TestMethod]
        public void RemoveRoom()
        {
                      



        }

    }
}
