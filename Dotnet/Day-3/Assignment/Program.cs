
namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Question-1
            CallByValueAndReference();
            // Question-2
            TryParseExample();
            // Question-3
            ArrayExample();
            // Question-4
            StringExample();
            // Question-5
            ForLoopExample();
        }

        static void CallByValueAndReference()
        {
            int a = 10;
            int b = 20;

            Console.WriteLine("Before CallByValue: a = " + a);
            CallByValue(a);
            Console.WriteLine("After CallByValue: a = " + a);

            Console.WriteLine("Before CallByReference: b = " + b);
            CallByReference(ref b);
            Console.WriteLine("After CallByReference: b = " + b);
        }

        static void CallByValue(int x)
        {
            x = 100;
            Console.WriteLine("Inside CallByValue: x = " + x);
        }

        static void CallByReference(ref int y)
        {
            y = 200;
            Console.WriteLine("Inside CallByReference: y = " + y);
        }

        static void TryParseExample()
        {
            string input = "123";
            bool result = int.TryParse(input, out int number);

            if (result)
                Console.WriteLine("Conversion successful: " + number);
            else
                Console.WriteLine("Conversion failed");
        }

        static void ArrayExample()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        static void StringExample()
        {
            string name = "Goutham";

            Console.WriteLine(name.Length);
            Console.WriteLine(name.ToUpper());
            Console.WriteLine(name.Substring(0, 4));
        }

        static void ForLoopExample()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
