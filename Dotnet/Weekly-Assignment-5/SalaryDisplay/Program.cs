using SalaryCalculator;

namespace SalaryDisplay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Employee Name: ");
                string empName = Console.ReadLine();

                Console.Write("Enter Basic Salary: ");
                if (!double.TryParse(Console.ReadLine(), out double basicSalary))
                {
                    throw new FormatException("Please enter a valid numeric salary.");
                }

                double netSalary = SalaryCalc.CalculateNetSalary(basicSalary);

                Console.WriteLine("\n--- Employee Salary Details ---");
                Console.WriteLine($"Employee Name : {empName}");
                Console.WriteLine($"Basic Salary  : {basicSalary:F2}");
                Console.WriteLine($"Net Salary    : {netSalary:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
