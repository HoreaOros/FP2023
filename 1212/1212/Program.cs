using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace _1212
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int[,] matrix;
            int rows = 4, cols = 5;
            matrix = InitRndMatrix(rows, cols, 100);

            PrintMatrix(matrix);
            Console.WriteLine($"Suma varfurilor din matrice este: {SumaVarfuri(matrix)}");

            // matrice patratrica = numarul de linii este egal cu numarul de coloane
            int lines = 5;
            matrix = InitRndMatrix(lines, 100);
            PrintMatrix(matrix);
            Console.WriteLine($"Suma elementelor de pe diagonala principala {SumDiagonalaPrincipala(matrix)}");

            Console.WriteLine($"Suma elementelor de pe diagonala secundara {SumDiagonalaSecundara(matrix)}");
            Console.WriteLine($"Suma elementelor din zona NORD este {SumNord(matrix)}");
            Console.WriteLine($"Suma elementelor din zona NORD este {SumNordReloaded(matrix)}");

            // Afisez toate elementele din zona de nord
            // in ordine crescatoare, o singura data
            // Elementele matricii sunt cifre;

            matrix = InitRndMatrix(7, 10);
            PrintMatrix(matrix);

            F(matrix);

        }

        private static void F(int[,] matrix)
        {
            int[] v = new int[10];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (i < j && i + j < matrix.GetLength(0) - 1)
                        v[matrix[i, j]]++;

            for(int i = 0; i < v.Length; i++)
                if (v[i] > 0)
                    Console.Write($"{i} ");
            Console.WriteLine();
        }

        private static int SumNordReloaded(int[,] matrix)
        {
            int sum = 0;
            int line = 0;
            int j_left = 1, j_right = matrix.GetLength(1) - 2;
            while(j_left <= j_right)
            {
                for(int j = j_left; j <= j_right; j++)
                    sum += matrix[line, j];
                line++;
                j_left++;
                j_right--;
            }
            return sum;
        }

        private static int SumNord(int[,] matrix)
        {
            int suma = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (i < j && i + j < matrix.GetLength(0) - 1)
                        suma += matrix[i, j];

            return suma;
        }

        /// <summary>
        /// 3x3, (0, 2), (1, 1), (2, 0) i + j == n - 1
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static int SumDiagonalaSecundara(int[,] matrix)
        {
            int suma = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                suma += matrix[i, matrix.GetLength(0) - 1 - i];
            return suma;
        }

        private static int SumDiagonalaPrincipala(int[,] matrix)
        {
            int suma = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                suma += matrix[i, i];
            return suma; 
        }

        private static int[,] InitRndMatrix(int lines, int maxValue)
        {
            return InitRndMatrix(lines, lines, maxValue);
        }

        private static int SumaVarfuri(int[,] matrix)
        {
            int suma = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (IsPeak(i, j, matrix))
                        suma += matrix[i, j];
            return suma;
        }

        private static bool IsPeak(int i, int j, int[,] matrix)
        {
            int[] dr = {-1, 1, 0, 0 };
            int[] dc = { 0, 0, -1, 1 };
            for (int k = 0; k < dr.Length; k++)
            {
                int ni = i + dr[k];
                int nj = j + dc[k];
                if(ni >= 0 && nj >= 0 && 
                    ni < matrix.GetLength(0) && 
                    nj < matrix.GetLength(1))
                {
                    if (matrix[ni, nj] >= matrix[i, j])
                        return false;
                }
            }
            return true;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],3} ");
                Console.WriteLine();
            }
        }

        private static int[,] InitRndMatrix(int rows, int cols, int maxValue)
        {
            int[,] m = new int[rows, cols];
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    m[i,j] = rnd.Next(0, maxValue);
            return m;
        }
    }
}
