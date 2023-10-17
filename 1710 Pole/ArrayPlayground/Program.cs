using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti čísly.
            int[] a = { 1, 2, 3, 4, 5 };

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus klasický for, kde i využiješ jako index v poli, a foreach (vysvětlíme si).
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0;
            foreach (int i in a)
            {
                sum += i;
            }

            Console.WriteLine("suma je " + sum);

            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            int average = sum / a.Length;
            Console.WriteLine("prumer je " + average);

            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = 0;
            foreach (int i in a)
            {
                if(i > max)
                {
                    max = i;
                }
            }
            Console.WriteLine("maximum je " + max);

            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min = a[0];
            foreach (int i in a)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            Console.WriteLine("minimum je " + min);

            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            Console.WriteLine("Zadejte prvek, jehoz index chcete najit");
            int wantedNum = Int32.Parse(Console.ReadLine());
            int index = -1;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == wantedNum)
                { 
                    Console.WriteLine("Index cisla je " + i);
                    index = i;
                    break;
                }
            }
            if(index == -1)
                Console.WriteLine("Cislo nebylo nalezeno");

            //TODO 8: Změň tvorbu integerového pole tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9. Vytvoř si na to proměnnou typu Random.
            int[] b = new int[100];
            Random rand = new Random();
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = rand.Next(10);
            }
            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach(int i in b)
            {
                counts[i]++;
            }
            for(int i = 0; i < counts.Length; i++)
            {
                Console.WriteLine("Pocet prvku hodnoty " + i + " je " + counts[i]);
            }

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] countsRev = new int[10];
            for(int i = 0; i < counts.Length; i++)
            {
                countsRev[counts.Length - i - 1] = counts[i];
            }
            Console.ReadKey();
        }
    }
}
