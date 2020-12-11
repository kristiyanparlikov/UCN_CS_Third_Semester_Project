using DataAccessLayer;
using DataAccessLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BookingHandler 
    {
        IBookingRepository db = new BookingRepository();

        public void CreateWithoutStudent(BookingModel entity)
        {
            db.AddAnonymous(entity);
        }

        public void Create(BookingModel entity, int studentId)
        {
            db.Add(entity, studentId);
        }

        public void Delete(int id)
        {
            db.Remove(id);
        }

        public BookingModel Get(int id)
        {
            return db.Find(id);
        }

        public IEnumerable<BookingModel> GetAll()
        {
            return db.GetAll();
        }

        public int Update(BookingModel entity)
        {
            return db.Update(entity);
        }

        public IEnumerable<BookingModel> GetAllBookingsOfStatus(int status)
        {
            return db.GetAllBookingsOfStatus(status);
        }

        public int changeBookingStatus(BookingStatus bookingStatus, int id)
        {
            return  db.changeBookingStatus(bookingStatus, id);
        }

        public int getBookingStatus(int id)
        {
            return db.getBookingStatus(id);
        }
    }
}
