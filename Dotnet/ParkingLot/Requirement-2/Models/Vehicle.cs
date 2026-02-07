using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2.Models
{
    public class Vehicle
    {
        // Private fields for the Vehicle class
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;

        // Public properties to access the private fields
        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public double Weight
        {
            get => _weight;
            set => _weight = value;
        }

        private Ticket _ticket;

        public Ticket Ticket
        {
            get => _ticket;
            set => _ticket = value;
        }

        // Default constructor for the Vehicle class
        public Vehicle()
        {

        }

        // Parameterized constructor to initialize the Vehicle object with given values
        public Vehicle(string _registrationNo, string _name, string _type, double _weight, Ticket _ticket)
        {
            RegistrationNo = _registrationNo;
            Name = _name;
            Type = _type;
            Weight = _weight;
            Ticket = _ticket;
        }

        // Override the ToString method to provide a string representation of the Vehicle object
        public override string ToString()
        {
            return $"Registration No:{RegistrationNo}\nName:{Name}\nType:{Type}\nWeight:{string.Format("{0:0.0}", Weight)}\nTicket No:{Ticket.TicketNo}";
        }

        // Override the Equals method to compare two Vehicle objects based on their RegistrationNo and Name properties
        public override bool Equals(object? obj)
        {
            Vehicle other = obj as Vehicle;
            return RegistrationNo == other.RegistrationNo && Name == other.Name;
        }


        public static Vehicle CreateVehicle(string detail)
        {
            string[] vehicleDetails = detail.Split(",");

            Ticket ticket= new Ticket(vehicleDetails[4], DateTime.ParseExact(vehicleDetails[5],"dd-MM-yyyy HH:mm:ss",null), Convert.ToDouble(vehicleDetails[6]));
            Vehicle vehicle = new Vehicle(vehicleDetails[0], vehicleDetails[1], vehicleDetails[2], Convert.ToDouble(vehicleDetails[3]), ticket);

            return vehicle;

        }
    }
}
