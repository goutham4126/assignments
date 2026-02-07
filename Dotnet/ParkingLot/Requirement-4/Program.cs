using Requirement_4.Models;
using Requirement_4.Services;

namespace Requirement_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                // Enter the number of vehicles
                Console.Write("Enter the number of vehicles :");
                int n = Convert.ToInt32(Console.ReadLine());

                for(int i=0;i<n;i++)
                {
                    string vehicleDetails = Console.ReadLine();
                    Vehicle vehicle = Vehicle.CreateVehicle(vehicleDetails);
                }

                Console.WriteLine("Enter a search type :\n1.By type\n2.By parked time\n3.Exit");

                // Enter the search type
                int searchType = Convert.ToInt32(Console.ReadLine());
                switch (searchType)
                {
                    case 1: 
                        Console.WriteLine("Enter the vehicle type :");
                        string type = Console.ReadLine();
                        // Get all vehicles
                        List<Vehicle> vehicles = Vehicle.GetAllVehicles();
                        VehicleBO vehicleBO = new VehicleBO();
                        // Find the vehicle by type
                        List<Vehicle> vehicleList = vehicleBO.FindVehicle(vehicles, type);
                        // Display the vehicle details
                        Console.Write("{0,-15}{1,-10}{2,-12}{3,-7}{4}\n", "Registration No", "Name", "Type", "Weight", "Ticket No");
                        foreach (Vehicle vehicle in vehicleList)
                        {
                            Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}", $"{vehicle.RegistrationNo}", $"{vehicle.Name}", $"{vehicle.Type}", $"{vehicle.Weight}", $"{vehicle.Ticket.TicketNo}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the parked time :");
                        // Enter the parked time in the format "dd-MM-yyyy HH:mm:ss"
                        DateTime parkedTime = DateTime.ParseExact(
                            Console.ReadLine(),
                            "dd-MM-yyyy HH:mm:ss",
                            null
                        );
                        // Get all vehicles
                        List<Vehicle> vehicles2 = Vehicle.GetAllVehicles();
                        VehicleBO vehicleBO2 = new VehicleBO();
                        // Find the vehicle by parked time
                        List<Vehicle> vehicleList2 = vehicleBO2.FindVehicle(vehicles2, parkedTime);
                        // Display the vehicle details
                        Console.Write("{0,-15}{1,-10}{2,-12}{3,-7}{4}\n", "Registration No", "Name", "Type", "Weight", "Ticket No");
                        foreach (Vehicle vehicle in vehicleList2)
                        {
                            Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}", $"{vehicle.RegistrationNo}", $"{vehicle.Name}", $"{vehicle.Type}", $"{vehicle.Weight}", $"{vehicle.Ticket.TicketNo}");
                        }


                        break;
                    case 3:
                        return;
                    default : 
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
        }
    }
}
