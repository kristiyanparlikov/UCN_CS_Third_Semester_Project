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
    public class BookingHandler : ICRUD<BookingModel>
    {
        IBookingRepository db = new BookingRepository();

        public void Create(BookingModel entity)
        {
            db.Add(entity);
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

        public void Update(BookingModel entity)
        {
            db.Remove(entity.Id);
        }
    }
}
