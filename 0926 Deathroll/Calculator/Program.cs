using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hra DEATHROLL.");
            Console.WriteLine("Zadejte prirozene cislo");

            string xStr = Console.ReadLine();
            int x;

            while (int.TryParse(xStr, out x) == false)
            {
                Console.WriteLine("Zadejte prirozene cislo");
                xStr = Console.ReadLine();
            }
            x = Int32.Parse(xStr);

            Random rnd = new Random();
            while (true)
            {
                x = rnd.Next(1, x + 1);
                Console.WriteLine("Padlo vam cislo " + x);

                if (x == 1)
                {
                    Console.WriteLine("Prohra :(");
                    break;
                }

                x = rnd.Next(1, x + 1);
                Console.WriteLine("Protihracovi padlo cislo " + x);

                if (x == 1)
                {
                    Console.WriteLine("Vyhra :)");
                    break;
                }

                Console.WriteLine("Zadejte enter pro pokracovani hry");
                xStr = Console.ReadLine();
            }

            

            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        }
    }
}
