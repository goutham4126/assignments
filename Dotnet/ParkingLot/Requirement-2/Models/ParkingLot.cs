using System;
using System.Collections.Generic;

namespace Requirement_2.Models
{
    public class ParkingLot
    {
        // Private fields
        private string _name;
        private List<Vehicle> _vehicleList;

        // Public property
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public ParkingLot()
        {
            _vehicleList = new List<Vehicle>();
        }

        // Constructor (parameterized)
        public ParkingLot(string name)
        {
            _name = name;
            _vehicleList = new List<Vehicle>();
        }

        // Add vehicle
        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                Console.WriteLine("Invalid vehicle.");
                return;
            }

            _vehicleList.Add(vehicle);
            Console.WriteLine("Vehicle added successfully.");
        }

        // Remove vehicle
        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            for (int i = 0; i < _vehicleList.Count; i++)
            {
                if (_vehicleList[i].RegistrationNo == registrationNo)
                {
                    _vehicleList.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        // Display vehicles
        public void DisplayVehicles()
        {
            if (_vehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show.");
                return;
            }

            Console.WriteLine($"\nVehicles in {Name}:");

            foreach (Vehicle vehicle in _vehicleList)
            {
                Console.Write("{0,-15}{1,-10}{2,-12}{3,-7}{4}\n","Registration No","Name","Type","Weight","Ticket No");
                Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}\n", $"{vehicle.RegistrationNo}", $"{vehicle.Name}", $"{vehicle.Type}", $"{string.Format("{0,0:0}",vehicle.Weight)}", $"{vehicle.Ticket.TicketNo}");
            }
        }
    }

}
