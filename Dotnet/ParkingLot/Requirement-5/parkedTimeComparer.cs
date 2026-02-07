using Requirement_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_5
{
    public class parkedTimeComparer: IComparer<Vehicle>
    {
        // As there were multiple sorting criteria,
        // we used the IComparer interface to create a
        // custom comparer for sorting vehicles based on their parked time.
        public int Compare(Vehicle? x, Vehicle? y)
        {
            return x.Ticket.ParkedTime.CompareTo(y.Ticket.ParkedTime);
        }
    }
}
