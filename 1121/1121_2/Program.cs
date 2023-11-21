using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1121_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DateTimeDemo();
            ArrayDemo();
            // TODO
            // implementati rutine alternative de Binary Search
            // si cautari aproximative cu binary search.
        }


        private static void ArrayDemo()
        {
            // Array = vector, tablou unidimensional
            // colectie de elemente, toate de acelasi tip, care pot fi accesate printr-un index
            int[] v;
            v = InitArray(42);
            PrintArray(v);

            //int[] v2 = GetArrayFromConsole();
            //PrintArray(v2);

            Array.Sort(v);
            PrintArray(v);

            if (Array.BinarySearch(v, 42) >= 0)
                Console.WriteLine("Valoarea a fost gasita");
            else
                Console.WriteLine("Valoarea nu a fost gasita");

            if (MyBinarySearch(v, 42) == -1)
                Console.WriteLine("Valoarea nu a fost gasita");
            else
                Console.WriteLine("Valoarea a fost gasita");

        }

        private static int MyBinarySearch(int[] v, int key)
        {
            int left = 0;
            int right = v.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                //int mid = left + (right - left) / 2;
                if (v[mid] == key)
                    return mid;
                else if (key < v[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }

        private static int[] GetArrayFromConsole()
        {
            string line = Console.ReadLine();
            string[] tokens = line.Split(new char[] {' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            int[] arr = new int[tokens.Length];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = int.Parse(tokens[i]);
            return arr;
        }

        private static void PrintArray(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }

        private static int[] InitArray(int n)
        {
            int[] arr = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-99, 100);
            }
            return arr;
        }

        private static void DateTimeDemo()
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(dateTime);
            Console.WriteLine(dateTime.Day);
            Console.WriteLine(dateTime.Hour);
            Console.WriteLine(dateTime.Minute);
            Console.WriteLine(dateTime.Second);
            Console.WriteLine(dateTime.Millisecond);
            Console.WriteLine(dateTime.DayOfYear);

            DateTime d2 = dateTime.AddDays(42);
            Console.WriteLine(d2);
            Console.WriteLine(dateTime.ToUniversalTime());



            TimeSpan ts = d2.Subtract(dateTime);
            Console.WriteLine(ts.Duration());


            int a1 = 2023, l1 = 11, z1 = 21;
            int a2 = 2000, l2 = 7, z2 = 25;

            Console.WriteLine($"Numarul de zile dintre cele doua date este: {DateDiff(z1, l1, a1, z2, l2 ,a2)}");


            DateTime today = DateTime.Now;
            DateTime dt = new DateTime(2000, 7, 25);
            Console.WriteLine(today.Subtract(dt).Days);
        }

        private static int DateDiff(int z1, int l1, int a1, int z2, int l2, int a2)
        {
            int zile = 0;
            // pp ca prima data este mai mare decat a doua 
            while (!(z1 == z2 && l1 == l2 && a1 == a2))
            {
                zile++;
                if (z1 > 1)
                    z1--;
                else
                {
                    switch(l1)
                    {
                        case 1:
                            z1 = 31;
                            l1 = 12;
                            a1--;
                            break;
                        case 2:
                        case 4:
                        case 6:
                        case 8:
                        case 9:
                        case 11:
                            z1 = 31;
                            l1--;
                            break;
                        case 5: case 7: case 10: case 12:
                            z1 = 30;
                            l1--;
                            break;
                        case 3:
                            l1 = 2;
                            if (AnBisect(a1))
                                z1 = 29;
                            else
                                z1 = 28;
                            break;
                    }
                }
            }

            return zile;
        }

        static bool AnBisect(int a)
        {
            return (a % 4 == 0 && a % 100 != 0) || (a % 400 == 0);
        }
    }
}
