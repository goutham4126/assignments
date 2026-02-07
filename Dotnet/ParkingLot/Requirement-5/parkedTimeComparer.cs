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
        public int Compare(Vehicle? x, Vehicle? y)
        {
            return x.Ticket.ParkedTime.CompareTo(y.Ticket.ParkedTime);
        }
    }
}
