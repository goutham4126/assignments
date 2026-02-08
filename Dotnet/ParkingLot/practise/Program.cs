using System;

namespace practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new Exception();
            }
            catch
            {
                return;
            }
            finally
            {
                Console.WriteLine("Finally");
            }

        }
    }
}
