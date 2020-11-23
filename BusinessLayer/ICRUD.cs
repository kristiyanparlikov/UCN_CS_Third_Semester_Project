using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    interface ICRUD<T>
    {
        void Create(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Update(T entity);
        bool Delete(int id);
    }
}
