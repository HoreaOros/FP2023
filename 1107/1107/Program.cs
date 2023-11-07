using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _1107
{
    internal class Program
    {
        private static void Coins()
        {
            int stake;
            int goal;
            int times = 10000;
            int wins = 0, losses = 0;


            Random rnd = new Random();

            for (int i = 1; i <= times; i++)
            {
                stake = 40;
                goal = 100;

                while (!(stake == 0 || goal == stake))
                    if (rnd.Next(2) == 0)
                        stake++;
                    else
                        stake--;
                
                if (stake == 0)
                    losses++;
                else if (stake == goal)
                    wins++;
            }

            Console.WriteLine($"Wins: {wins}, Losses: {losses}");
        }

        /// <summary>
        /// Determina oglinditul/rasturantul unui numar
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <example>pt 123 intorc 321</example>
        static int oglindit(int n)
        {
            int result = 0;
            int cifra;
            while (n > 0)
            {
                cifra = n % 10;
                n = n / 10;
                result = result * 10  + cifra;
            }

            return result;
        }
        static bool estePalindrom(int n)
        {
            return n == oglindit(n);
        }
        static void Main(string[] args)
        {
            //// Palindrom ******************
            //int n = 12322;
            //Console.Write($"Numarul {n} ");
            //if (!estePalindrom(n))
            //    Console.Write("nu ");
            //Console.WriteLine("este palindrom");
            //// **************************


            // Divizibilitate
            //int n = 16;
            //Console.WriteLine($"Numarul {n} are {NumarDivizori2(n)} divizori");
            //n = 50;
            //Rooms1(n);
            //Rooms2(n);

            Coins();
        }

        private static int NumarDivizori2(int n)
        {
            if (n < 1)
                throw new ArgumentException("Numarul e invalid");
            if (n == 1)
                return 1;
            int result = 2;
            int divisor = 2;
            while (divisor * divisor < n)
            {
                if (n % divisor == 0)
                    result += 2;

                divisor++;
            }
            if (divisor * divisor == n)
                result++;

            return result;
        }

        private static void Rooms2(int n)
        {
            int cnt = 0;

            int d = 1;
            while (d * d <= n)
            {
                cnt++;
                d++;
            }

            //Console.WriteLine($"Numarul de camere inchise la final este: {Math.Floor(Math.Sqrt(n))}");
            Console.WriteLine($"Numarul de camere inchise la final este: {cnt}");

        }

        private static void Rooms1(int n)
        {
            bool[] r = new bool[n + 1];
            for (int z = 1; z <= n; z++)
            {
                int m = 1;
                while (m * z <= n)
                {
                    r[m * z] = !r[m * z];
                    m++;
                }
            }
            int cnt = 0;
            for (int i = 1; i <= n; i++)
            {
                if (r[i] == true)
                {
                    cnt++;
                }
            }
            Console.WriteLine($"Numarul de camere inchise la final este: {cnt}");
        }

        private static object NumarDivizori1(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException("Numarul e invalid");
            }
            if (n == 1)
                return 1;

            int cnt = 0;
            for (int d = 1; d <= n; d++)
            {
                if(n % d == 0)
                    cnt++;
            }
            return cnt;
        }
    }
}
