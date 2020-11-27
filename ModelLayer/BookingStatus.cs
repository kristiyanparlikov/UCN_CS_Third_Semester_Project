using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public enum BookingStatus : int
    {
        New = 0,
        Pending = 1,
        Accepted = 2,
        Cancelled = 3,
        Living = 4,
        Notice = 5
    }
}
