using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1003
{
    internal class Program
    {
        static void f(int n)
        {
            Console.Write($"{n} ");
            while (n != 1)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = 3 * n + 1;
                }
                Console.Write($"{n} ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int n; 
            //n = int.Parse(Console.ReadLine());
            //Console.WriteLine(n);


            for (int i = 1; i <= 10000; i++)
            {
                f(i);
            }
            

        }
    }
}
