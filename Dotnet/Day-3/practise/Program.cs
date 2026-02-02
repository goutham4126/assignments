using System.Text;
using System.Globalization;

namespace practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Abs(-1));

            int[] numbers = new int[10];
            numbers[0] = 1;
            numbers[1] = 3;

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            Array.Sort(numbers);
            Array.Reverse(numbers);

            // Sort and reverse on array is mutable

            Console.OutputEncoding = Encoding.UTF8;

            double amount = 1000.56;
            Console.WriteLine(amount.ToString("C", new CultureInfo("en-IN")));


            Console.WriteLine(Convert.ToInt32(null));

            //Call by value
            int a = 10;
            f1(a);
            Console.WriteLine(a);

            //Call by reference
            int b = 10;
            f2(ref b);
            Console.WriteLine(b);

            //Call by out
            int c = 10;
            f3(out c);
            Console.WriteLine(c);

            //string s = "hello";
            //s[0] = 'W';
            //Console.WriteLine(s);

            string name = "Goutham";
            bool val = int.TryParse(name, out int number);
            if (val)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("Invalid number");
            }

        }

        public static void f1(int x)
        {
            x = 20;
            Console.WriteLine(x);
        }

        public static void f2(ref int x)
        {
           
            Console.WriteLine(x);
            x = 20;
        }

        public static void f3(out int x)
        {
            x = 20;
            Console.WriteLine(x);
        }

    }
}
