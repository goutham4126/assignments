using System;
using System.Collections.Generic;
using System.Linq;

namespace practise
{
    class MeltdownEventArgs : EventArgs
    {
        private string message;

        public MeltdownEventArgs(string message)
        {
            this.message = message;
        }

        public string Message
        {
            get { return message; }
        }
    }


    class Reactor
    {
        private int temperature;

        public delegate void MeltdownHandler(object reactor, MeltdownEventArgs myMEA);

        public event MeltdownHandler OnMeltdown;

        public int Temperature
        {
            set
            {
                temperature = value;

                if (temperature > 1000)
                {
                    MeltdownEventArgs myMEA =
                        new MeltdownEventArgs("Reactor meltdown in progress!");

                    OnMeltdown?.Invoke(this, myMEA);
                }
            }
        }
    }

    class ReactorMonitor
    {
        public ReactorMonitor(Reactor myReactor)
        {
            myReactor.OnMeltdown +=
                new Reactor.MeltdownHandler(DisplayMessage);
        }

        public void DisplayMessage(object myReactor, MeltdownEventArgs myMEA)
        {
            Console.WriteLine(myMEA.Message);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Reactor myReactor = new Reactor();
            ReactorMonitor myReactorMonitor =
                new ReactorMonitor(myReactor);

            Console.WriteLine("Setting reactor temperature to 100 degrees Centigrade");
            myReactor.Temperature = 100;

            Console.WriteLine("Setting reactor temperature to 500 degrees Centigrade");
            myReactor.Temperature = 500;

            Console.WriteLine("Setting reactor temperature to 2000 degrees Centigrade");
            myReactor.Temperature = 2000;


            List<int> nums = new List<int> {1,11,32,41,15,16,27,38,29,10};
            var evenNums = nums.Where(n => n % 2 == 0);
            foreach (var num in evenNums)
            {
                Console.WriteLine(num);
            }

            var oddNums = from n in nums
                          where n % 2 != 0
                          select n;
            foreach (var n in oddNums)
            {
                Console.WriteLine(n);
            }

            var squares = from n in nums
                          where n % 2 == 0
                          select n * n;

            foreach (var n in squares)
            {
                Console.WriteLine(n);
            }

            var sortedNumbers = from n in nums
                                orderby n descending
                                select n;
            foreach (var n in sortedNumbers)
            {
                Console.WriteLine(n);
            }

            int totalSum = nums.Sum();
            int count = nums.Count();
            int min = nums.Min();
            int max = nums.Max();

            Console.WriteLine("Sum : " + totalSum + " " + "Count : " + count + " " + "Min : " + min + " " + "Max : " + max);



        }
    }
}
