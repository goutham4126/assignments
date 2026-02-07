using Requirement_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4.Services
{
    public class VehicleBO
    {
        // Method to find vehicles belonging to a particular type
        public List<Vehicle> FindVehicle(List<Vehicle>vehicleList, string type)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            foreach (Vehicle vehicle in vehicleList) {
                if (vehicle.Type == type) {
                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }

        // Method to find vehicles belonging to a particular parked time
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (Vehicle vehicle in vehicleList) {
                if (vehicle.Ticket.ParkedTime == parkedTime) {
                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }
    }
}
