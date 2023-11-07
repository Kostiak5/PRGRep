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
        static void writeArray(int[,] arr, int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.Write("\n");
            }
            return;
        }

        static int[,] fillArray(int[,] arr, int x, int y, int fillMethod)
        {
            Random rd = new Random();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (fillMethod == 1)
                        arr[i, j] = rd.Next(100);
                    else
                        arr[i, j] = i * 5 + j + 1;
                }
            }

            writeArray(arr, x, y);
            return arr;
        }

        static int[,] swapElement(int[,] arr, int x, int y)
        {
            int ax = 0, ay = 0;
            string axInput = "", ayInput = "";
            do
            {
                Console.WriteLine("Zadej postupne radek a sloupec tveho prvniho prvku, ktery chces prohodit.");
                Console.WriteLine("Pokud se zprava zobrazi vickrat, zadavas neplatnou hodnotu.");
                axInput = Console.ReadLine();
                ayInput = Console.ReadLine();
            } while (!Int32.TryParse(axInput, out ax) || !Int32.TryParse(ayInput, out ay) || ax >= x || ay >= y);
            ax = Int32.Parse(axInput);
            ay = Int32.Parse(ayInput);

            int bx = 0, by = 0;
            string bxInput = "", byInput = "";
            do
            {
                Console.WriteLine("Zadej postupne radek a sloupec tveho druheho prvku, ktery chces prohodit.");
                Console.WriteLine("Pokud se zprava zobrazi vickrat, zadavas neplatnou hodnotu.");
                bxInput = Console.ReadLine();
                byInput = Console.ReadLine();
            } while (!Int32.TryParse(bxInput, out bx) || !Int32.TryParse(byInput, out by) || bx >= x || by >= y);
            bx = Int32.Parse(bxInput);
            by = Int32.Parse(byInput);

            int temp = arr[ax, ay];
            arr[ax, ay] = arr[bx, by];
            arr[bx, by] = temp;

            writeArray(arr, x, y);
            return arr;
        }

        static int[,] swapRow(int[,] arr, int x, int y)
        {
            int ax = 0, bx = 0;
            string axInput = "", bxInput = "";
            do
            {
                Console.WriteLine("Zadej postupne prvni radek a druhy radek, ktere chces prohodit.");
                Console.WriteLine("Pokud se zprava zobrazi vickrat, zadavas neplatnou hodnotu.");
                axInput = Console.ReadLine();
                bxInput = Console.ReadLine();
            } while (!Int32.TryParse(axInput, out ax) || !Int32.TryParse(bxInput, out bx) || ax >= x || bx >= x);

            for(int i = 0; i < y; i++)
            {
                int temp = arr[ax, i];
                arr[ax, i] = arr[bx, i];
                arr[bx, i] = temp;
            }

            writeArray(arr, x, y);
            return arr;
        }

        static int[,] swapColumn(int[,] arr, int x, int y)
        {
            int ay = 0, by = 0;
            string ayInput = "", byInput = "";
            do
            {
                Console.WriteLine("Zadej postupne prvni sloupec a druhy sloupec, ktere chces prohodit.");
                Console.WriteLine("Pokud se zprava zobrazi vickrat, zadavas neplatnou hodnotu.");
                ayInput = Console.ReadLine();
                byInput = Console.ReadLine();
            } while (!Int32.TryParse(ayInput, out ay) || !Int32.TryParse(byInput, out by) || ay >= y || by >= y);

            for (int i = 0; i < x; i++)
            {
                int temp = arr[i, ay];
                arr[i, ay] = arr[i, by];
                arr[i, ay] = temp;
            }

            writeArray(arr, x, y);
            return arr;
        }

        static int[,] swapDiagonal(int[,] arr, int x, int y, bool mainD)
        {
            if(x != y)
            {
                Console.WriteLine("Matice neni ctvercova, bohuzel tedy nelze otoceni prvku na diagonale provest.");
                return arr;
            }

            for (int i = 0; i <= x / 2; i++)
            {
                int reverseI = x - i - 1;
                if (mainD)
                {
                    int temp = arr[i, i];
                    arr[i, i] = arr[reverseI, reverseI];
                    arr[reverseI, reverseI] = arr[i, i];
                } else
                {
                    int temp = arr[i, reverseI];
                    arr[i, reverseI] = arr[reverseI, i];
                    arr[reverseI, i] = arr[i, reverseI];
                }
                
                
            }

            writeArray(arr, x, y);
            return arr;
        }

        static int[,] multiplyByNumber(int[,] arr, int x, int y, bool mainD)
        {
            /*int multiplier = 0;
            string multiplierString = "";
            do
            {
                Console.WriteLine("Zadej cislo, kterym chces matici vynasobit.");
                Console.WriteLine("Pokud se zprava zobrazi vickrat, zadavas neplatnou hodnotu.");
                ayInput = Console.ReadLine();
            } while (!Int32.TryParse(ayInput, out ay) || !Int32.TryParse(byInput, out by) || ay >= y || by >= y);
            */
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                }
            }

            writeArray(arr, x, y);
            return arr;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Zadej pocet radku v matici: ");
            int x = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Zadej pocet sloupcu v matici: ");
            int y = Int32.Parse(Console.ReadLine());
            int[,] arr = new int[x, y];
            Console.WriteLine("Zadej 1, pokud chces matici naplnit nahodnymi cisly.");
            Console.WriteLine("Zadej 2, pokud chces matici naplnit za sebou jdoucimi cisly pocinaje jednickou.");
            int fillMethod = Int32.Parse(Console.ReadLine()); //fillMethod je 1 => cisla nahodna, fillMethod neni 1 => cisla od 1 do x*y

            arr = fillArray(arr, x, y, fillMethod); //cv. 1

            do
            {
                Console.WriteLine("1 pro prohozeni prvku, 2 pro prohozeni radku, 3 pro prohozeni sloupcu");
                Console.WriteLine("4 pro otoceni poradi prvku po hl. diagonale, 5 po vedl. diagonale");
                Console.WriteLine("6 pro secteni dvou matic, 7 pro odecteni dvou matic");

                int operation = 0;
                string operationInput = "";
                do
                {
                    Console.WriteLine("Zadej cislo operace kterou chces provest.");
                    Console.WriteLine("Pokud se toto zobrazi vickrat, zadavas neplatnou hodnotu.");
                    operationInput = Console.ReadLine();
                } while (!Int32.TryParse(operationInput, out operation));
                operation = Int32.Parse(operationInput);

                switch (operation)
                {
                    case 1:
                        arr = swapElement(arr, x, y);
                        break;
                    case 2:
                        arr = swapRow(arr, x, y);
                        break;
                    case 3:
                        arr = swapColumn(arr, x, y);
                        break;
                    case 4:
                        arr = swapDiagonal(arr, x, y, true);
                        break;
                    case 5:
                        arr = swapDiagonal(arr, x, y, false);
                        break;
                    case 6:
                        arr = multiplyByNumber(arr, x, y);
                        break;
                }

                Console.WriteLine("Zadej ANO pro ukonceni programu, pokud zadas cokoliv jineho, budes moct pokracovat v provadeni operaci s matici.");
            }
            while (Console.ReadLine() != "ANO");
            Console.ReadKey();
        }
    }
}
