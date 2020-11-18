using DataAccessLayer;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Runner
{
    class Program
    {
        private static IConfigurationRoot config;

        static void Main(string[] args)
        {
            Initialize();

            Get_all_should_return_0_result();

            Console.ReadLine();
        }

        static void Get_all_should_return_0_result()
        {
            //arrange
            var repository = CreateRepository();

            //act
            var bookings = repository.GetAll();

            //assert
            Console.WriteLine($"Count: {bookings.Count}");
            Debug.Assert(bookings.Count == 0);
            bookings.Output();
        }

        private static void Initialize()
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            config = builder.Build();
        }

        private static IBookingRepository CreateRepository()
        {
            return new BookingRepository(config.GetConnectionString("DefaultConnection"));
        }
    }
}
