using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2.Models
{
    public class Ticket
    {
        // Private fields for the Ticket class
        private string _ticketNo;
        private DateTime _parkedTime;
        private double _cost;

        // Public properties to access the private fields
        public string TicketNo
        {
            get => _ticketNo;
            set => _ticketNo = value;
        }

        public DateTime ParkedTime
        {
            get => _parkedTime;
            set => _parkedTime = value;
        }

        public double Cost
        {
            get => _cost;
            set => _cost = value;
        }

        // Default constructor for the Ticket class
        public Ticket()
        {

        }

        // Parameterized constructor to initialize the Ticket object with given values
        public Ticket(string _ticketNo, DateTime _parkedTime, double _cost)
        {
            TicketNo = _ticketNo;
            ParkedTime = _parkedTime;
            Cost = _cost;
        }

        // Override the ToString method to provide a string representation of the Ticket object
        public override string ToString()
        {
            return $"{TicketNo}";
        }
    }
}
