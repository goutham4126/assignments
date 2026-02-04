using InsuranceLibrary.Models;
using InsuranceLibrary.Services;

namespace InsuranceConsoleApp
{
    internal class Program
    {
        static PolicyService service = new PolicyService();

        static void AddPolicy()
        {
            Console.Write("Enter Policy Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Holder Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Policy Type: ");
            string type = Console.ReadLine();

            Console.Write("Enter Premium Amount: ");
            decimal premium = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Policy Term (years): ");
            int term = int.Parse(Console.ReadLine());

            Console.Write("Is Active (true/false): ");
            bool active = bool.Parse(Console.ReadLine());

            InsurancePolicy policy = new InsurancePolicy(id, name, type, premium, term, active);
            service.AddPolicy(policy);

            Console.WriteLine("Policy Added Successfully!");
        }

        static void ViewPolicies()
        {
            var policies = service.GetAllPolicies();

            if (policies.Count == 0)
            {
                Console.WriteLine("No policies found.");
                return;
            }

            foreach (var p in policies)
            {
                Console.WriteLine(p);
            }
        }

        static void SearchPolicy()
        {
            Console.Write("Enter Policy Id to search: ");
            int id = int.Parse(Console.ReadLine());

            var policy = service.GetPolicyById(id);

            if (policy == null)
                Console.WriteLine("Policy not found.");
            else
                Console.WriteLine(policy);
        }

        static void UpdatePolicy()
        {
            Console.Write("Enter Policy Id to update: ");
            int id = int.Parse(Console.ReadLine());

            var existing = service.GetPolicyById(id);
            if (existing == null)
            {
                Console.WriteLine("Policy not found.");
                return;
            }

            Console.Write("Enter new Premium Amount: ");
            decimal premium = decimal.Parse(Console.ReadLine());

            Console.Write("Enter new Policy Term: ");
            int term = int.Parse(Console.ReadLine());

            existing.PremiumAmount = premium;
            existing.PolicyTerm = term;

            service.UpdatePolicy(existing);
            Console.WriteLine("Policy Updated Successfully!");
        }

        static void DeletePolicy()
        {
            Console.Write("Enter Policy Id to delete: ");
            int id = int.Parse(Console.ReadLine());

            if (service.DeletePolicy(id))
                Console.WriteLine("Policy Deleted Successfully!");
            else
                Console.WriteLine("Policy not found.");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n0-Exit 1-Add 2-View 3-Search 4-Update 5-Delete");
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0: return;
                    case 1: AddPolicy(); break;
                    case 2: ViewPolicies(); break;
                    case 3: SearchPolicy(); break;
                    case 4: UpdatePolicy(); break;
                    case 5: DeletePolicy(); break;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }
    }
}
