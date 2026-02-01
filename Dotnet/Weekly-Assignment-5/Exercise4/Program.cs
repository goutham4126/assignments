namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int prev, curr, units;
            double amount = 0;
            string type;

            Console.WriteLine("Enter Customer Id:");
            string id = Console.ReadLine();

            Console.WriteLine("Enter Customer Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Customer Address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter Customer Phone Number:");
            string number = Console.ReadLine();

            Console.WriteLine("Enter Customer Email Id:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Connection Type (Industrial/Business/Domestic/Agricultural):");
            type = Console.ReadLine();

            Console.WriteLine("Enter Previous Reading:");
            prev = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Current Reading:");
            curr = Convert.ToInt32(Console.ReadLine());

            units = curr - prev;

            if (units <= 100)
                amount = units * 1.5;
            else if (units <= 250)
                amount = (100 * 1.5) + (units - 100) * 2.5;
            else if (units <= 550)
                amount = (100 * 1.5) + (150 * 2.5) + (units - 250) * 4.5;
            else
                amount = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + (units - 550) * 7.5;

            int meterRent = 0;

            if (type == "Industrial")
                meterRent = 2500;
            else if (type == "Business")
                meterRent = 1500;
            else if (type == "Domestic")
                meterRent = 1000;
            else if (type == "Agricultural")
                meterRent = 0;

            double total = amount + meterRent;

            Console.WriteLine("\n \t Electricity Bill \n");
            Console.WriteLine("Customer ID : " + id);
            Console.WriteLine("Customer Name : " + name);
            Console.WriteLine("Customer Email : " + email);
            Console.WriteLine("Customer Phone : " + number);
            Console.WriteLine("Customer Address : " + address);
            Console.WriteLine("Units Used    : " + units);
            Console.WriteLine("Bill Amount   : " + amount);
            Console.WriteLine("Meter Rent    : " + meterRent);
            Console.WriteLine("Total Amount  : " + total);

        }
    }
}