namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double xa, ya, ra, xb, yb, rb;

            Console.WriteLine("Enter Circle A center :");
            xa = Convert.ToDouble(Console.ReadLine());
            ya = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Circle A radius :");
            ra = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Circle B center :");
            xb = Convert.ToDouble(Console.ReadLine());
            yb = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Circle B radius :");
            rb = Convert.ToDouble(Console.ReadLine());

            double d = Math.Sqrt(Math.Pow(xb - xa, 2) + Math.Pow(yb - ya, 2));

            if (d + rb < ra)
                Console.WriteLine("B is in A");
            else if (d + ra < rb)
                Console.WriteLine("A is in B");
            else if (d < ra + rb)
                Console.WriteLine("A and B intersect");
            else
                Console.WriteLine("A and B do not intersect");

        }
    }
}
