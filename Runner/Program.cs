using DataAccessLayer;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
using ModelLayer;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UCNThirdSemesterProject.ModelLayer;

namespace Runner
{
    class Program
    {

        static void Main(string[] args)
        {
            //Initialize();

            //Get_all_should_return_1_result();

            //Insert_should_assign_identity_to_new_entity();

            //Find_should_retrieve_existing_entity(2);

            //Modify_should_update_existing_entity(4);

            //Delete_should_remove_entitiy(4);

            //Insert_full_booking_should_update_all_related_tables();

            //Insert_should_assign_identity_to_new_entity();

            //Insert_admin_should_add_new_entity();

            Console.ReadLine();
        }

        //private static void Initialize()
        //{
        //    var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
        //       .SetBasePath(Directory.GetCurrentDirectory())
        //       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    config = builder.Build();
        //}

        private static IStudentRepository CreateStudentRepository()
        {
            return new StudentRepository();
        }

        //private static AdministratorRepository CreateAdministratorRepository()
        //{
        //    return new AdministratorRepository();
        //}

        private static IBookingRepository CreateBookingRepository()
        {
            return new BookingRepository();
        }

        private static IBookingRepository CreateBookingRepositoryAdoNet()
        {
            return new BookingRepositoryAdoNet();
        }

        //static void Insert_admin_should_add_new_entity()
        //{
        //    //arrange
        //    //var administratorRepository = CreateAdministratorRepository();
        //    var administratorRepository = new AdministratorRepository();
        //    //act
        //    var admin = new AdministratorModel()
        //    {
        //        FirstName = "John",
        //        LastName = "Johnson",
        //        Email = "J@J.com",
        //        PhoneNumber = "+4512534211",
        //        EmployeeNumber = 404
        //    };
        //    int rowsAffected = administratorRepository.Add(admin);

        //    //assert
        //    Debug.Assert(rowsAffected == 1);
        //    if(rowsAffected == 1)
        //    {
        //        Console.WriteLine("***Administrator inserted***");
        //    }
            
        //}

        //static int Insert_full_booking_should_update_all_related_tables()
        //{
        //    //arrange 
        //    var bookingRepository = CreateBookingRepositoryAdoNet();
        //    var studentRepository = CreateStudentRepository();

        //    //var student = new StudentModel
        //    //{
        //    //    FirstName = "Kristiyan",
        //    //    LastName = "Parlikov",
        //    //    PhoneNumber = "+4500000000",
        //    //    Email = "K@p.com",
        //    //    DateOfBirth = DateTime.Parse("2000-12-09"),
        //    //    Nationality = "Bulgarian",
        //    //    EducationEndDate = DateTime.Parse("2022-01-31")
        //    //};
        //    //var student = studentRepository.Find(1);
        //    var booking = new BookingModel
        //    {
        //        MoveInDate = DateTime.Parse("2021-01-01"),
        //        MoveOutDate = student.EducationEndDate,
        //        Status = "New"
        //    };

        //    //act
        //    bookingRepository.AddFull(booking, student);

        //    //assert
        //    Debug.Assert(booking.Id != 0);
        //    Console.WriteLine("***Booking inserted***");
        //    Console.WriteLine($"New ID: {booking.Id}");
        //    return booking.Id;

        //}

        static void Delete_should_remove_entitiy(int id)
        {
            //arrange
            var bookingRepository = CreateBookingRepository();

            //act   
            bookingRepository.Remove(id);

            //create a new repository for verification purposes 
            var bookingRepository2 = CreateBookingRepository();
            var deletedBooking = bookingRepository2.Find(id);

            //assert
            Debug.Assert(deletedBooking == null);
            Console.WriteLine("***Contact Deleted***");
        }

        static void Modify_should_update_existing_entity(int id)
        {
            //arrange
            var bookingRepository = CreateBookingRepository();

            //act
            var booking = bookingRepository.Find(id);
            booking.MoveInDate = DateTime.Parse("2021-03-01");
            bookingRepository.Update(booking);

            //create a new repository for verification purposes 
            var bookingRepository2 = CreateBookingRepository();
            var modifiedBooking = bookingRepository2.Find(id);

            //assert
            Console.WriteLine("***Contact Modified***");
            modifiedBooking.Output();
            Debug.Assert(modifiedBooking.MoveInDate == DateTime.Parse("2021-03-01"));
        }

        private static void Get_all_should_return_1_result()
        {
            //arrange
            var studentRepository = CreateStudentRepository();
            var bookingRepository = CreateBookingRepositoryAdoNet();

            //act
            var bookings = bookingRepository.GetAll();
            var students = studentRepository.GetAll();

            //assert
            Console.WriteLine($"Count: {bookings.Count}");
            //Debug.Assert(bookings.Count == 1);
            bookings.Output();

            Console.WriteLine($"Count: {students.Count}");
            Debug.Assert(students.Count == 1);
            students.Output();
        }

        private static void Find_should_retrieve_existing_entity(int id)
        {
            //arrange 
            var bookingRepository = CreateBookingRepositoryAdoNet();

            //act
            var booking = bookingRepository.Find(id);

            Console.WriteLine("***Get Booking***");
            booking.Output();
            //Debug.Assert(booking.MoveInDate == DateTime.Parse("2021-01-01"));
            //Debug.Assert(booking.MoveOutDate == DateTime.Parse("2021-03-15"));
        }

        private static int Insert_should_assign_identity_to_new_entity()
        {
            //arrange
            var bookingRepository = CreateBookingRepositoryAdoNet();
            var booking = new BookingModel
            {
                MoveInDate = DateTime.Parse("2021-12-21"),
                MoveOutDate = DateTime.Parse("2022-11-11"),
                Status = "Pending"
            };

            //act
            bookingRepository.AddAnonymous(booking);

            //assert 
            Debug.Assert(booking.Id != 0);
            Console.WriteLine("***Booking inserted***");
            Console.WriteLine($"New ID: {booking.Id}");
            return booking.Id;
        }

        
    }
}
