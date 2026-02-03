namespace OOPSDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Emp e = new Emp();

            e.EmpSalary = 101;

            Console.WriteLine(e.EmpSalary);



            Console.Write("Enter the name of employee : ");
            e.EmpName = Console.ReadLine();

            Emp e1 = new Emp(101, "Ramesh", 45000);

            Console.WriteLine(e1);

        }
    }
}
