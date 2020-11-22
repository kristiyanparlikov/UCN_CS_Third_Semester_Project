using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class DormitoryModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int NDayNotice { get; set; }

        public DormitoryModel(int id, string name, int nDayNotice)
        {
            Id = id;
            Name = name;
            NDayNotice = nDayNotice;
        }

        public DormitoryModel(string name, int nDayNotice)
        {
            Name = name;
            NDayNotice = nDayNotice;
        }
    }
}
