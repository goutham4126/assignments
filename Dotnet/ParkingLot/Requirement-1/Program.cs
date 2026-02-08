using Requirement_1.Models;

namespace Requirement_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Enter the details of two vehicles in the format: RegistrationNo,Name,Type,Weight,TicketNo,ParkedTime,Cost

            try
            {
                Console.Write("Enter Vechile 1 details : ");
                string v1 = Console.ReadLine();
                Console.Write("Enter Vechile 2 details : ");
                string v2 = Console.ReadLine();


                // Split the input details and create Vehicle and Ticket objects
                string[] v1Array = v1.Split(",");
                string[] v2Array = v2.Split(",");

                if (v1Array.Length != 7 || v2Array.Length != 7)
                {
                    throw new Exception();
                }


                Ticket ticket1 = new Ticket(v1Array[4], Convert.ToDateTime(v1Array[5]), Convert.ToDouble(v1Array[6]));
                Ticket ticket2 = new Ticket(v2Array[4], Convert.ToDateTime(v2Array[5]), Convert.ToDouble(v2Array[6]));

                Console.WriteLine("\nVehicle 1\n");
                Vehicle vehicle1 = new Vehicle(v1Array[0], v1Array[1], v1Array[2], Convert.ToDouble(v1Array[3]), ticket1);
                Console.WriteLine(vehicle1);

                Console.WriteLine("\nVehicle 2\n");
                Vehicle vehicle2 = new Vehicle(v2Array[0], v2Array[1], v2Array[2], Convert.ToDouble(v2Array[3]), ticket2);
                Console.WriteLine(vehicle2);

                // Compare the two vehicles using the overridden Equals method
                if (vehicle1.Equals(vehicle2))
                {
                    Console.WriteLine("\nVehicle 1 is same as Vehicle 2");
                }
                else
                {
                    Console.WriteLine("\nVehicle 1 and Vehicle 2 are different");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please enter the details in the correct format.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return;
            }
        }
    }
}