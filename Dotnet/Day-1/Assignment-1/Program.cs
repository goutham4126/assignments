namespace Assignment_1
{
    internal class Program
    {
        public static void sumOfArray()
        {
            int number, n;
            Console.WriteLine("Enter size of array: ");
            n = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                number = Convert.ToInt32(Console.ReadLine());
                sum += number;
            }
            Console.WriteLine("sum is: " + sum);
        }

        public static int largestNumber(int a, int b)
        {
            Console.WriteLine("Largest Number is:");
            if(a < b)
            {
                return b;
            }
            else
            {
                return a;
            }
        }

        public static void Factorial_number(int number)
        {
            int fact = 1;
            for (int i = 1; i <= number; i++)
            {
                fact = fact * i;
            }
            Console.WriteLine("Factorial of a number is : " + fact);
        }

        public static void prime_composite(int number)
        {
            bool isprime = true;

            if (number <= 1)
            {
                isprime = false;
            }

            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    isprime = false;
                    break;
                }
            }

            if (isprime)
            {
                Console.WriteLine(number + " is a Prime number");
            }
            else
            {
                Console.WriteLine(number + " is not a Prime number");
            }
        }

        public static void LargestNumberInArray()
        {
            int[] arr = { 10, 4, 5, 6, 7 };
            int largest = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > largest)
                {
                    largest = arr[i];
                }
            }
            Console.WriteLine("Largest number in array is: " + largest);
        }

        static void Main(string[] args)
        {
            sumOfArray();

            int x = largestNumber(10, 5);
            Console.WriteLine(x);

            Factorial_number(5);

            prime_composite(10);

            LargestNumberInArray();


        }
    }
}
