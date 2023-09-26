﻿using System;
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
            Console.WriteLine("Program KALKULACKA.");
            Console.WriteLine("Vysvetlivky: \n operace ^ je mocnina prvniho cisla o zakladu druhe cislo \n operace root je odmocnina z prvniho cisla o zakladu druhe cislo \n operace log je logaritmus z prvniho cisla o zakladu druhe cislo");
            bool continues = false;
            do
            {
                Console.WriteLine("Zadej prvni cislo:");
                string aString = Console.ReadLine();

                Console.WriteLine("Zadej druhe cislo:");
                string bString = Console.ReadLine();
                double a, b;

                while (!double.TryParse(aString, out a) || !double.TryParse(bString, out b)) //dokud cisla nejsou zadana spravne, chtej po nem vstup znovu
                {
                    Console.WriteLine("Nespravny vstup, zadej jeste jednou");
                    Console.WriteLine("Zadej prvni cislo:");
                    aString = Console.ReadLine();
                    Console.WriteLine("Zadej druhe cislo:");
                    bString = Console.ReadLine();
                }

                a = double.Parse(aString);
                b = double.Parse(bString);
                double result = 0.0f;

                Console.WriteLine("Zadej mat. operaci: \n(Moznosti operaci: +, -, *, /, ^, root, log)");
                bool falseOperation = true; //overuje, zda je mat. operace zadana spravne
                while (falseOperation)
                {

                    string operation = Console.ReadLine();
                    falseOperation = false;
                    switch (operation)
                    {
                        case "+":
                            result = a + b;
                            Console.WriteLine(result);
                            break;
                        case "-":
                            result = a - b;
                            Console.WriteLine(result);
                            break;
                        case "*":
                            result = a * b;
                            Console.WriteLine(result);
                            break;
                        case "/":
                            result = a / b;
                            Console.WriteLine(result);
                            break;
                        case "^":
                            result = Math.Pow(a, b);
                            Console.WriteLine(result);
                            break;
                        case "root":
                            result = Math.Pow(a, 1/b);
                            Console.WriteLine(result);
                            break;
                        case "log":
                            result = Math.Log(a, b);
                            Console.WriteLine(result);
                            break;
                        default:
                            Console.WriteLine("Nespravne zadana mat. operace, zadej jeste jednou. Moznosti operaci: +, -, *, /, ^, root, log");
                            falseOperation = true;
                            break;
                    }

                    if(falseOperation == false)
                    {
                        Console.WriteLine("Chcete pokracovat? Zadejte ANO pro pokracovani, cokoliv jineho program ukonci");
                        string continueStr = Console.ReadLine();
                        if (continueStr == "ANO")
                        {
                            continues = true;
                        }
                    }
                    
                }
            }
            while (continues == true);
            
            
            /*
            if (oper == "+")
            {
                result = ai + bi;
                Console.WriteLine(result);
            }
            else if (oper == "-")
            {
                result = ai - bi;
                Console.WriteLine(result);
            }
            else if (oper == "*")
            {
                result = ai * bi;
                Console.WriteLine(result);
            }
            else if (oper == "/")
            {
                result = ai / bi;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(result);
            }*/
            /*
             * Pokud se budes chtit na neco zeptat a zrovna budu pomahat jinde, zkus se zeptat ChatGPT ;) - https://chat.openai.com/
             * 
             * ZADANI
             * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
             * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
             * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
             * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
             * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
             * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
             * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
             *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
             * 7) Vypis promennou result do konzole
             * 
             * Mozna rozsireni programu pro rychliky / na doma (na poradi nezalezi):
             * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces
             * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
             * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
             *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
             * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
             */

            //Tento komentar smaz a misto nej zacni psat svuj prdacky kod.

            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        }
    }
}