using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1031
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000;
            //TestPrimes(n);

            Numbers3();

        }

        /// <summary>
        /// Se citesc de la tastatura 3 numere (numerele
        /// sunt pe o singura linie separate prin delimitatori)
        /// Cele 3 numere trebuie afisate in ordine crescatoare.
        /// </summary>
        /// <example>5  4;,2 ==> 2 4 5</example>
        private static void Numbers3()
        {
            string line = Console.ReadLine();
            char[] sep = { ' ', ';', ',', '\'', '\"' };

            string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            int num1 = int.Parse(tokens[0]);
            int num2 = int.Parse(tokens[1]);
            int num3 = int.Parse(tokens[2]);
            Console.WriteLine($"{num1} {num2} {num3}");

            int minim = num1;
            if (num2 < minim)
                minim = num2;
            if(num3 < minim)
                minim = num3;
            
            int maxim = num1;
            if (num2 > maxim)
                maxim = num2;
            if (num3 > maxim)
                maxim = num3;

            Console.WriteLine($"{minim} {num1+num2+num3-minim-maxim} {maxim}");
        }

        private static void TestPrimes(int n)
        {
            int contor = 0;
            for (int num = 2; num <= n; num++)
            {
                if (EstePrim7(num))
                {  
                    contor++; 
                    //Console.WriteLine($"Numarul {num} este prim");
                }

                else
                {
                    //Console.WriteLine($"Numarul {num} nu este prim");

                }
            }
            Console.WriteLine($"Numarul de numere prime este {contor}");
        }

        /// <summary>
        /// Probabilistic primality test
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool EstePrim7(int num)
        {
            // Fermat
            // Soloway-Strassen
            // Miller–Rabin
            return false;
        }

        private static bool EstePrim6(int n)
        {
            if (n < 2)
                return false;
            if (n == 2 || n == 3)
                return true;
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            for (int d = 5; d * d <= n; d += 6)
                if (n % d == 0 || n % (d + 2) == 0)
                    return false;


            return true;
        }

        private static bool EstePrim5(int n)
        {
            if (n < 2)
                return false;
            if (n == 2 || n == 3)
                return true;
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            for (int d = 3; d*d<=n; d += 2)
                if (n % d == 0)
                    return false;


            return true;
        }

        private static bool EstePrim4(int n)
        {
            if (n < 2)
                return false;
            if(n == 2 || n == 3)
                return true;
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            for (int d = 3; d <= n / 2; d+= 2)
                if (n % d == 0)
                    return false;


            return true;
        }

        private static bool EstePrim3(int n)
        {
            if (n < 2)
                return false;

            for (int d = 2; d <= n / 2; d++)
                if (n % d == 0)
                    return false;


            return true;
        }

        private static bool EstePrim2(int n)
        {
            if (n < 2)
                return false;
            int contor = 2;
            for (int d = 2; d <= n / 2; d++)
                if (n % d == 0)
                    contor++;

            return contor == 2;
        }

        private static bool EstePrim1(int n)
        {
            if (n < 2)
                return false;
            int contor = 0;
            for (int d = 1; d <= n; d++)
                if (n % d == 0)
                    contor++;
            
            return contor == 2;
        }
        
    }
}
