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
            Console.WriteLine("Hra KÁMEN-NŮŽKY-PAPÍR. Pro konec zadejte slovo konec.");

            Console.WriteLine("kámen, nůžky nebo papír?");
            string player = Console.ReadLine();

            Random rnd = new Random();
            while (player != "konec" && player != null)
            {
                int pcInt = rnd.Next(3);
                if (pcInt == 0)
                {
                    if (player == "kámen")
                    {
                        Console.WriteLine("remíza, hrajte znovu");
                    }
                    else if (player == "nůžky")
                    {
                        Console.WriteLine("prohra, soupeř vybral kámen :(");
                    }
                    else if (player == "papír")
                    {
                        Console.WriteLine("výhra, soupeř vybral kámen :)");
                    }
                }
                else if (pcInt == 1)
                {
                    if (player == "nůžky")
                    {
                        Console.WriteLine("remíza, hrajte znovu");
                    }
                    else if (player == "papír")
                    {
                        Console.WriteLine("prohra, soupeř vybral nůžky :(");
                    }
                    else if (player == "kámen")
                    {
                        Console.WriteLine("výhra, soupeř vybral nůžky :)");
                    }
                }
                else if (pcInt == 2)
                {
                    if (player == "papír")
                    {
                        Console.WriteLine("remíza, hrajte znovu");
                    }
                    else if (player == "kámen")
                    {
                        Console.WriteLine("prohra, soupeř vybral papír :(");
                    }
                    else if (player == "nůžky")
                    {
                        Console.WriteLine("výhra, soupeř vybral papír :)");
                    }
                }
                player = Console.ReadLine();
            }

            

            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        }
    }
}
