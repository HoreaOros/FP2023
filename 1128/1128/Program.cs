using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1128
{
    internal class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            Console.Write("Generating ...");
            int[] ints = InitArray(1000000);
            Console.WriteLine("Done.");


            Console.Write("Sorting...");
            //Array.Sort(ints);
            //BubbleSort(ints);
            //SelectionSort(ints);
            InsertionSort(ints);
            //QuickSort(ints);
            Console.WriteLine("Done");
            //PrintArray(ints);

        }
// _# choose pivot_
//swap a[1, rand(1, n)]

//_# 2-way partition_
//k = 1
//for i = 2:n, if a[i] < a[1], swap a[++k, i]
//swap a[1, k]
//_→ invariant: a[1..k - 1] < a[k] <= a[k + 1..n] _

//_# recursive sorts_
//sort a[1..k - 1]
//sort a[k + 1, n]
        private static int Partition(int[] ints, int st, int dr)
        {
            int k = st;
            for (int i = st + 1; i <= dr; i++)
                if (ints[i] < ints[st])
                {
                    k++;
                    (ints[i], ints[k]) = (ints[k], ints[i]);
                }
            (ints[st], ints[k]) = (ints[k], ints[st]);
            return k;
        }
        private static void QuickSort(int[] ints)
        {
            QuickSortHelper(ints, 0, ints.Length - 1);
        }

        private static void QuickSortHelper(int[] ints, int st, int dr)
        {
            if(st < dr)
            {
                int idx =  r.Next(st, dr + 1);
                (ints[st], ints[idx]) = (ints[idx], ints[st]);
                int k = Partition(ints, st, dr);

                QuickSortHelper(ints, st, k - 1);
                QuickSortHelper(ints, k + 1, dr);
            }
        }


        //for i = 2:n,
        //    for (k = i; k > 1 and a[k] < a[k - 1]; k--)
        //        swap a[k, k - 1]
        //    → invariant: a[1..i] is sorted
        //end
        private static void InsertionSort(int[] ints)
        {
            for (int i = 1; i < ints.Length; i++)
                for (int k = i; k > 0 && ints[k] < ints[k - 1]; k--)
                    (ints[k - 1], ints[k]) = (ints[k], ints[k - 1]);
        }

        // for i = 1:n,
        //    k = i
        //    for j = i+1:n, if a[j] < a[k], k = j
        //    → invariant: a[k] smallest of a[i..n]
        //    swap a[i, k]
        //    → invariant: a[1..i] in final position
        //end
        private static void SelectionSort(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                int k = i;
                for (int j = i + 1; j < ints.Length; j++)
                    if (ints[j] < ints[k])
                        k = j;
                int aux;
                aux = ints[i];
                ints[i] = ints[k]; ;
                ints[k] = aux;
            }
        }


        //    for i = 1:n,
        //      swapped = false
        //      for j = n:i+1,
        //          if a[j] < a[j - 1],
        //              swap a[j, j - 1]
        //              swapped = true
        //      → invariant: a[1..i] in final position
        //      break if not swapped
        //    end 
        private static void BubbleSort(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                bool swapped = false;
                for (int j = ints.Length - 1; j >= i + 1; j--)
                    if (ints[j] < ints[j - 1])
                    {
                        (ints[j], ints[j - 1]) = (ints[j - 1], ints[j]);
                        swapped = true;
                    }
                if (!swapped)
                    break;
            }
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

    }
}
