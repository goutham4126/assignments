using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_6.Models
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

        // Default constructor for the Vehicle class
        public Vehicle()
        {

        }

        // Parameterized constructor to initialize the Vehicle object with given values
        public Vehicle(string _registrationNo, string _name, string _type, double _weight)
        {
            RegistrationNo = _registrationNo;
            Name = _name;
            Type = _type;
            Weight = _weight;
        }

        // Override the ToString method to provide a string representation of the Vehicle object
        public override string ToString()
        {
            return $"Registration No:{RegistrationNo}\nName:{Name}\nType:{Type}\nWeight:{string.Format("{0:0.0}", Weight)}";
        }

        // Override the Equals method to compare two Vehicle objects
        // based on their RegistrationNo and Name properties
        public override bool Equals(object? obj)
        {
            Vehicle other = obj as Vehicle;
            return RegistrationNo == other.RegistrationNo && Name == other.Name;
        }

        // Static method to create a Vehicle object from a comma-separated string of details
        public static Vehicle CreateVehicle(string detail)
        {
            string[] vehicleDetails = detail.Split(",");
            Vehicle vehicle = new Vehicle(vehicleDetails[0], vehicleDetails[1], vehicleDetails[2], double.Parse(vehicleDetails[3]));

            return vehicle;
        }

        // Static method to count the number of vehicles of each type
        // in a list of Vehicle objects and return a sorted dictionary
        // with the type as the key and the count as the value
        public static SortedDictionary<string, int>TypeWiseCount(List<Vehicle>vehicleList)
        {
            SortedDictionary<string, int> typeWiseCount = new SortedDictionary<string, int>();
            foreach (Vehicle vehicle in vehicleList)
            {
                if (typeWiseCount.ContainsKey(vehicle.Type))
                {
                    typeWiseCount[vehicle.Type]++;
                }
                else
                {
                    typeWiseCount.Add(vehicle.Type, 1);
                }
            }
            return typeWiseCount;
        }
    }
}
