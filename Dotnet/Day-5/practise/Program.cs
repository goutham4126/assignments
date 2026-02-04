using System.Collections;

namespace practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArayList, Stack, Queue, Hashtable are non-generic collections
            //ArrayList myList = new ArrayList();
            //myList.Add(1);
            //myList.Add("Hello");
            //myList.Add(3.14);
            //myList.Add(true);

            //foreach (var item in myList)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(myList[1]);

            //for (int i = 0; i < myList.Count; i++)
            //{
            //    Console.WriteLine(myList[i]);
            //}


            //List, Dictionary, HashSet are generic collections
            //List<int> numbers = new List<int>();
            //numbers.Add(10);
            //numbers.Add(20);
            //numbers.Add("Goutham");

            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}

            //Dictionary<string, int> ages = new Dictionary<string, int>();
            //ages.Add("Alice", 30);
            //ages.Add("Bob", 25);
            //foreach (var kvp in ages)
            //{
            //    Console.WriteLine($"{kvp.Key} is {kvp.Value} years old.");
            //}

            //List<int> nums = new List<int> {15,23,23,334,56 };

            //foreach(int num in nums)
            //{
            //    Console.WriteLine(num);
            //}

            //nums.Sort();

            // We cannot sort a list conatining non-primitive types. We can only sort using IComparable.

            // public class Emp: IComparable<Emp>

            // public int CompareTo(Emp other)
            //{
            // return this.Id.CompareTo(other.Id);
            //}

            Emp e1 = new Emp("Goutham", 101, 75000.00m);
            Emp e2 = new Emp("Goutham", 101, 75000.00m);

            List<Emp> empList = new List<Emp>
            {
                e1,
                new Emp("Alice", 102, 80000.00m),
                new Emp("Bob", 100, 70000.00m)
            };

            //empList.Sort();
            empList.Sort(new DeptNameWiseComparer());

            foreach (Emp emp in empList)
            {
                Console.WriteLine(emp);
            }

            if(e1.Equals(e2))
            {
                Console.WriteLine("e1 and e2 are equal.");
            }
            else
            {
                Console.WriteLine("e1 and e2 are not equal.");
            }

        }

    }
}
