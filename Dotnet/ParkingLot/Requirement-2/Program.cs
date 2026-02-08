using Requirement_2.Models;

namespace Requirement_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Enter the name of the parking lot
            Console.WriteLine("Enter the name of the parking lot:");
            string parkingLotName = Console.ReadLine();

            // Create a parking lot object with the entered name
            ParkingLot parkingLot = new ParkingLot();
            parkingLot.Name = parkingLotName;


            // Display the menu and perform operations based on user choice
            while (true)
            {
                Console.WriteLine("1. Add Vehicle\n2. Delete Vehicle\n3. Display Vehicles\n4. Exit");
                Console.WriteLine("Enter your choice:");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        // Add Vehicle
                        case 1:
                            Console.WriteLine("Enter the details of the vehicle:");
                            string detail = Console.ReadLine();
                            Vehicle vehicle = Vehicle.CreateVehicle(detail);
                            parkingLot.AddVehicleToParkingLot(vehicle);

                            break;

                        // Delete Vehicle
                        case 2:
                            Console.WriteLine("Enter the registration number of the vehicle to be deleted in parking lot:");
                            string registrationNo = Console.ReadLine();

                            if (parkingLot.RemoveVehicleFromParkingLot(registrationNo))
                            {
                                Console.WriteLine("Vehicle successfully deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Vehicle not found in parking lot.");
                            }

                            break;

                        // Display Vehicles
                        case 3:
                            parkingLot.DisplayVehicles();
                            break;

                        case 4:
                            return;

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            }
        }
    }
}
