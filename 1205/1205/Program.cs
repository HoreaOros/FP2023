using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _1205
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 3, 6, 2, 1, 5, 7, 2, 4, 1, 9 };
            int C = 10;

            NextFit(v, C);
            FirstFit(v, C);
            BestFit(v, C);
            WorstFit(v, C);

            Console.WriteLine("*************************");
            Array.Sort(v, (x, y) => y - x);

            NextFit(v, C);
            FirstFit(v, C);
            BestFit(v, C);
            WorstFit(v, C);



        }

        private static void WorstFit(int[] v, int C)
        {
            Console.WriteLine("***Worst Fit***");
            List<int> bins = new List<int>();
            Console.WriteLine("Opening new bin");
            bins.Add(0);



            for (int i = 0; i < v.Length; i++)
            {
                int minim = int.MaxValue;
                int bestBin = -1;
                for (int j = 0; j < bins.Count; j++)
                    if (v[i] + bins[j] <= C)
                        if (v[i] + bins[j] < minim)
                        {
                            minim = v[i] + bins[j];
                            bestBin = j;
                        }
                if (bestBin != -1)
                {
                    bins[bestBin] += v[i];
                    Console.WriteLine($"Inserting weight {v[i]} in bin {bestBin + 1}");

                }
                else
                {
                    Console.WriteLine("Opening new bin");
                    bins.Add(v[i]);
                    Console.WriteLine($"Inserting weight {v[i]} in bin {bins.Count}");
                }
            }
            Console.WriteLine($"Total Bins used = {bins.Count}");

        }

        private static void BestFit(int[] v, int C)
        {
            Console.WriteLine("***Best Fit***");
            List<int> bins = new List<int>();
            Console.WriteLine("Opening new bin");
            bins.Add(0);



            for (int i = 0; i < v.Length; i++)
            {
                int maxim = 0;
                int bestBin = -1;
                for(int j = 0; j < bins.Count; j++)
                    if (v[i] + bins[j] <= C)
                        if (v[i]+ bins[j] > maxim)
                        {
                            maxim = v[i] + bins[j];
                            bestBin = j;
                        }
                if (bestBin != -1)
                {
                    bins[bestBin] += v[i];
                    Console.WriteLine($"Inserting weight {v[i]} in bin {bestBin + 1}");

                }
                else
                {
                    Console.WriteLine("Opening new bin");
                    bins.Add(v[i]);
                    Console.WriteLine($"Inserting weight {v[i]} in bin {bins.Count}");
                }
            }
            Console.WriteLine($"Total Bins used = {bins.Count}");


        }

        private static void FirstFit(int[] v, int C)
        {
            Console.WriteLine("***First Fit***");
            List<int> bins = new List<int>();
            Console.WriteLine("Opening new bin");
            bins.Add(0);

            for (int i = 0; i < v.Length; i++)
            {
                int j = 0;
                while (j < bins.Count && bins[j] + v[i] > C)
                    j++;
                if (j < bins.Count)
                {
                    bins[j] += v[i];
                    Console.WriteLine($"Inserting weight {v[i]} in bin {j + 1}");

                }
                else
                {
                    Console.WriteLine("Opening new bin");
                    bins.Add(v[i]);
                    Console.WriteLine($"Inserting weight {v[i]} in bin {bins.Count}");


                }
            }
            Console.WriteLine($"Total Bins used = {bins.Count}");


        }

        private static void NextFit(int[] v, int C)
        {
            Console.WriteLine("***Next Fit***");
            int bins = 1;
            Console.WriteLine("Opening new bin");

            int currentCapacity = 0;

            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] + currentCapacity <= C)
                {
                    currentCapacity += v[i];
                }
                else
                {
                    bins++;
                    Console.WriteLine("Opening new bin");
                    currentCapacity = v[i];
                }
                Console.WriteLine($"Inserting weight {v[i]} in bin {bins}");
            }

            Console.WriteLine($"Total Bins used = {bins}");

        }
    }
}
