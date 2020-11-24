using DataAccessLayer;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNThirdSemesterProject.ModelLayer;

namespace BusinessLayer
{
    public class BookingHandler 
    {
        IBookingRepository db = new BookingRepositoryAdoNet();

        public void Create(BookingModel entity)
        {
            db.AddAnonymous(entity);
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
    }
}
