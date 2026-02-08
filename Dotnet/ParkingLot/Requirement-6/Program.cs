using Requirement_6.Models;

namespace Requirement_6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of vehicles :");
            int n = Convert.ToInt32(Console.ReadLine());

            List<Vehicle> vehicleList = new List<Vehicle>();

            try
            {
                for (int i = 0; i < n; i++)
                {
                    string detail = Console.ReadLine();
                    // Create a Vehicle object using the CreateVehicle method and add it to the list
                    Vehicle vehicle = Vehicle.CreateVehicle(detail);
                    vehicleList.Add(vehicle);
                }

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }



            SortedDictionary<string,int> vehicles= Vehicle.TypeWiseCount(vehicleList);

            Console.WriteLine("Type\t \tNo. of Vehicles");

            // Iterate through the SortedDictionary and print the type and count of vehicles
            foreach (KeyValuePair<string,int> vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Key+"\t"+vehicle.Value);
            }


        }
    }
}
