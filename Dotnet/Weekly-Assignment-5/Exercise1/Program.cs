namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of matches:");
            int n = Convert.ToInt32(Console.ReadLine());

            int num=0;

            for(int i=1;i<=n;i++)
            {
                num = i*(i-1)*(i+1);
                Console.Write(num + " ");
            }

        }
    }
}
