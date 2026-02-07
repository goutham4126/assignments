using Requirement_5.Models;

namespace Requirement_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of the vehicles :");
            int n = Convert.ToInt32(Console.ReadLine());
        
            List<Vehicle> vehicles = new List<Vehicle>();
            for (int i=0;i<n;i++)
            {
                string vehicleDetails = Console.ReadLine();
                // split the details 
                string[] details = vehicleDetails.Split(",");
                // create a ticket object and a vehicle object and add the vehicle to the list
                Ticket ticket = new Ticket(details[4], DateTime.ParseExact(details[5], "dd-MM-yyyy HH:mm:ss", null), Convert.ToDouble(details[6]));
                Vehicle vehicle = new Vehicle(details[0], details[1], details[2], Convert.ToDouble(details[3]), ticket);
                vehicles.Add(vehicle);
            }

            Console.WriteLine("Enter the type of sort :\n1.Sort by Weight\n2.Sort by parked time");
            int choice = Convert.ToInt32(Console.ReadLine());

            // sort the vehicles based on the choice
            if (choice == 1)
            {
                vehicles.Sort();
            }
            else if(choice == 2)
            {
                vehicles.Sort(new parkedTimeComparer());
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            // print the sorted list of vehicles
            Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}", "RegistrationNo", "Name", "Type", "Weight", "TicketNo");
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine("{0,-15}{1,-10}{2,-12}{3,-7}{4}", $"{vehicle.RegistrationNo}", $"{vehicle.Name}", $"{vehicle.Type}", $"{string.Format("{0:0.0}", vehicle.Weight)}", $"{vehicle.Ticket.TicketNo}");
            }

        }
    }
}
