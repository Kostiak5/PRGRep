using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej pocet radku v matici: ");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Zadej pocet sloupcu v matici: ");
            int b = Int32.Parse(Console.ReadLine());
            int[,] arr = new int[a, b];
            Console.WriteLine("Zadej 1, pokud chces matici naplnit nahodnymi cisly.");
            Console.WriteLine("Zadej 2, pokud chces matici naplnit postupne.");
            int fillMethod = Int32.Parse(Console.ReadLine());
            if(fillMethod == 1)
            {
                Random random = new Random();
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        a[i, j] = random.Next(100);
                        Console.Write(a[i, j] + " ");
                    }
                    Console.Write("\n");
                }
            }
            else
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = i * 5 + j + 1;
                        Console.Write(arr[i, j] + " ");
                    }
                    Console.Write("\n");
                }
            }
            

            Console.ReadKey();
        }
    }
}
