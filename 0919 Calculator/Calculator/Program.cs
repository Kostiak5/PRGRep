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
        static bool isInputCorrect(string aString, double a, string bString, double b, string operation)
        {
            if (!double.TryParse(aString, out a) || !double.TryParse(bString, out b))
                return false;
            else { 
                a = double.Parse(aString);
                b = double.Parse(bString);
                if (operation == "/" && b == 0.0d) //nelze delit 0
                    return false;
                else if (operation == "root" && a < 0)
                    return false;
                else if (operation == "log" && (a < 0 || b <= 0 || b == 1))
                    return false;

                return true;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Program KALKULACKA.");
            Console.WriteLine("Vysvetlivky pro nektere operace: \n operace ^ je mocnina prvniho cisla o zakladu druhe cislo \n operace root je odmocnina z prvniho cisla o zakladu druhe cislo \n operace log je logaritmus z prvniho cisla o zakladu druhe cislo");
            bool continues = true;


            while (continues)
            {
                Console.WriteLine("Zadej mat. operaci: \n(Moznosti operaci: +, -, *, /, ^, root, log)");
                bool falseOperation = true; //overuje, zda je mat. operace zadana spravne
                string[] operationOptions = { "+", "-", "*", "/", "^", "root", "log" }; //seznam povolenych mat. operaci
                string operation = ""; //operace zadana uzivatelem

                while (falseOperation)
                {
                    operation = Console.ReadLine();

                    for (int i = 0; i < operationOptions.Length; i++)
                    {
                        if (operationOptions[i] == operation)
                        {
                            falseOperation = false;
                            break;
                        }
                    }

                    if (falseOperation)
                    {
                        Console.WriteLine("Nespravne zadana mat. operace, zadej ji jeste jednou (podle moznosti uvedenych nahore):");
                    }
                }

                Console.WriteLine("Zadej prvni cislo:");
                string aString = Console.ReadLine();

                Console.WriteLine("Zadej druhe cislo:");
                string bString = Console.ReadLine();

                double a = 0.0, b = 0.0;

                while (!isInputCorrect(aString, a, bString, b, operation) || falseOperation) //dokud cisla nejsou zadana spravne, chtej po nem vstup znovu
                {
                    Console.WriteLine("Nespravny vstup nebo reseni neexistuje, zadej cisla jeste jednou (operace zustava stejna):");
                    Console.WriteLine("Zadej prvni cislo:");
                    aString = Console.ReadLine();
                    Console.WriteLine("Zadej druhe cislo:");
                    bString = Console.ReadLine();
                }

                a = double.Parse(aString);
                b = double.Parse(bString);
                double result = 0.0d;

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
                        result = Math.Pow(a, 1 / b);
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

                Console.WriteLine("Chcete pokracovat? Zadejte ANO pro pokracovani, cokoliv jineho program ukonci");
                string continueStr = Console.ReadLine();
                if (continueStr != "ANO")
                {
                    continues = false;
                }
            }
            Console.ReadKey(); //stisk klavesy pro skonceni 
        }
    }
}
