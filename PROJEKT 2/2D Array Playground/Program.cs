using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        static int convertTesting(string inputStr, int limit) 
        //inputStr = to, co chceme prevest na integer
        //limit = pokud to uloha vyzaduje, zkontrolujeme, zda je int v rozmezi od 0 do tohoto cisla (vetsinou kontrola, zda je promenna v rozmezi velikosti pole); pokud to uloha nevyzaduje, tuto funkci vyvolame s parametrem limit = -1
        {
            int convertedNum = 0;

            while (!Int32.TryParse(inputStr, out convertedNum) || (limit != -1 && (Int32.Parse(inputStr) >= limit || Int32.Parse(inputStr) < 0))) //pokud uzivatel zada neciselnou hodnotu, prip. honde mimo rozmezi
            {
                if(!Int32.TryParse(inputStr, out convertedNum))
                {
                    Console.WriteLine("Neplatna hodnota, zadej hodnotu jeste jednou.");
                } else
                {
                    Console.WriteLine("Hodnota neodpovida rozmezi, zadej hodnotu jeste jednou.");
                }
                inputStr = Console.ReadLine();
            }
            
            convertedNum = Int32.Parse(inputStr);
            return convertedNum;
        }
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
                        arr[i, j] = i * y + j + 1;
                }
            }

            writeArray(arr, x, y);
            return arr;
        }

        static int[,] createSecondArray(int[,] arr, int x, int yDefault, bool multiplication)
        {
            int y = yDefault;
            //v pripade scitani a odcitani musi byt pocet radku a sloupcu obou matic identicky; v pripade nasobeni muze uzivatel libovolne nastavit pocet sloupcu nove matice
            if(multiplication) //tato promenna je 1, pokud jsme funkci vyvolali pro nasledne nasobeni matic
            {
                x = arr.GetLength(1);
                Console.WriteLine("Pocet radku nove matice = pocet sloupcu puvodni matice. (viz pravidla nasobeni matic)");
                Console.WriteLine("Zadej pocet sloupcu nove matice.");
                string yInput = Console.ReadLine();
                y = convertTesting(yInput, Int32.MaxValue);
            }
            Console.WriteLine("Zadej 1, pokud chces novou matici naplnit nahodnymi cisly.");
            Console.WriteLine("Zadej cokoliv jineho, pokud chces matici naplnit za sebou jdoucimi cisly pocinaje jednickou.");
            int[,] secondArr = new int[x, y];
            string fillMethod = Console.ReadLine();
            int fillMethodInt = 0;

            Console.WriteLine("Nove pole: ");
            if (Int32.TryParse(fillMethod, out fillMethodInt) && Int32.Parse(fillMethod) == 1)
                fillArray(secondArr, x, y, 1);
            else
                fillArray(secondArr, x, y, 2);

            
            return secondArr;
        }

        static int[,] swapElement(int[,] arr, int x, int y)
        {
            Console.WriteLine("Zadej radek prvniho prvku, ktery chces prohodit.");
            string axInput = Console.ReadLine();
            int ax = convertTesting(axInput, x);
            Console.WriteLine("Zadej sloupec prvniho prvku, ktery chces prohodit.");
            string ayInput = Console.ReadLine();
            int ay = convertTesting(ayInput, y);

            Console.WriteLine("Zadej radek druheho prvku, ktery chces prohodit.");
            string bxInput = Console.ReadLine();
            int bx = convertTesting(bxInput, x);
            Console.WriteLine("Zadej sloupec druheho prvku, ktery chces prohodit.");
            string byInput = Console.ReadLine();
            int by = convertTesting(byInput, y);

            int temp = arr[ax, ay];
            arr[ax, ay] = arr[bx, by];
            arr[bx, by] = temp;

            Console.WriteLine("Vysledek: ");
            writeArray(arr, x, y);
            return arr;
        }

        static int[,] swapRow(int[,] arr, int x, int y)
        {
            Console.WriteLine("Zadej poradi prvniho radku, ktery chces prohodit.");
            string axInput = Console.ReadLine();
            int ax = convertTesting(axInput, x);

            Console.WriteLine("Zadej poradi druheho radku, ktery chces prohodit.");
            string bxInput = Console.ReadLine();
            int bx = convertTesting(bxInput, x);

            for (int i = 0; i < y; i++)
            {
                int temp = arr[ax, i];
                arr[ax, i] = arr[bx, i];
                arr[bx, i] = temp;
            }

            Console.WriteLine("Vysledek: ");
            writeArray(arr, x, y);
            return arr;
        }

        static int[,] swapColumn(int[,] arr, int x, int y)
        {
            Console.WriteLine("Zadej poradi prvniho sloupce, ktery chces prohodit.");
            string ayInput = Console.ReadLine();
            int ay = convertTesting(ayInput, y);

            Console.WriteLine("Zadej poradi druheho sloupce, ktery chces prohodit.");
            string byInput = Console.ReadLine();
            int by = convertTesting(byInput, y);

            for (int i = 0; i < x; i++)
            {
                int temp = arr[i, ay];
                arr[i, ay] = arr[i, by];
                arr[i, by] = temp;
            }

            Console.WriteLine("Vysledek: ");
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

            Console.WriteLine("Vysledek: ");
            writeArray(arr, x, y);
            return arr;
        }

        static int[,] multiplyByNumber(int[,] arr, int x, int y)
        {
            Console.WriteLine("Zadej cislo, kterym chces celou matici vynasobit.");
            string multiplierInput = Console.ReadLine();
            int multiplier = convertTesting(multiplierInput, -1);

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    arr[i, j] *= multiplier;
                }
            }

            Console.WriteLine("Vysledek: ");
            writeArray(arr, x, y);
            return arr;
        }

        static int[,] addArrays(int[,] arr, int[,] secondArr, int x, int y)
        {
            int[,] sumArr = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    sumArr[i, j] = arr[i, j] + secondArr[i, j];
                }
            }

            Console.WriteLine("Vysledek: ");
            writeArray(sumArr, x, y);
            Console.WriteLine("Zadej ANO, pokud chces dal pocitat s touto vyslednou matici. Cokoliv jineho bude znamenat, ze dale budes pocitat znovu s puvodni matici.");
            if (Console.ReadLine() == "ANO")
                return sumArr;

            return arr;
        }

        static int[,] substractArrays(int[,] arr, int[,] secondArr, int x, int y)
        {
            int[,] subArr = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    subArr[i, j] = arr[i, j] - secondArr[i, j];
                }
            }

            Console.WriteLine("Vysledek: ");
            writeArray(subArr, x, y);
            Console.WriteLine("Zadej ANO, pokud chces dal pocitat s touto vyslednou matici. Cokoliv jineho bude znamenat, ze dale budes pocitat znovu s puvodni matici.");
            if (Console.ReadLine() == "ANO")
                return subArr;

            return arr;
        }

        static int[,] multiplyArrays(int[,] arr, int[,] secondArr, int x, int y)
        {
            int[,] multArr = new int[x, y];
            int z = arr.GetLength(1); //pocet sloupcu 1. matice a zaroven pocet radku 2. matice
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for(int k = 0; k < z; k++)
                    {
                        multArr[i, j] += (arr[i, k] * secondArr[k, j]); //kazdy z prvku vysledne matice je souctem nasobeni vsech prvku i-teho radku 1. matice a j-teho sloupce 2. matice
                    }
                }
            }

            Console.WriteLine("Vysledek: ");
            writeArray(multArr, x, y);
            Console.WriteLine("Zadej ANO, pokud chces dal pocitat s touto vyslednou matici. Cokoliv jineho bude znamenat, ze dale budes pocitat znovu s puvodni matici.");
            if (Console.ReadLine() == "ANO")
                return multArr;

            return arr;
        }

        static int[,] transposition(int[,] arr, int x, int y)
        {
            int[,] transArr = new int[y, x]; //vytvorime matici, kde pocet radku a sloupcu je oproti puvodni matici prohozeny
            for(int i = 0; i < y; i++)
            {
                for(int j = 0; j < x; j++)
                {
                    transArr[i, j] = arr[j, i];
                }
            }

            Console.WriteLine("Vysledek: ");
            writeArray(transArr, y, x);
            Console.WriteLine("Zadej ANO, pokud chces dal pocitat s touto vyslednou matici. Cokoliv jineho bude znamenat, ze dale budes pocitat znovu s puvodni matici.");
            if (Console.ReadLine() == "ANO")
                return transArr;

            return arr;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Zadej pocet radku v matici: ");
            string xInput = Console.ReadLine();
            int x = convertTesting(xInput, Int32.MaxValue);
            Console.WriteLine("Zadej pocet sloupcu v matici: ");
            string yInput = Console.ReadLine();
            int y = convertTesting(yInput, Int32.MaxValue);

            int[,] arr = new int[x, y];
            int[,] secondArr = new int[x, y]; //bude pozdeji pouzita pro scitani a odcitani jako pomocna druha matice

            Console.WriteLine("Zadej 1, pokud chces matici naplnit nahodnymi cisly.");
            Console.WriteLine("Zadej cokoliv jineho, pokud chces matici naplnit za sebou jdoucimi cisly pocinaje jednickou.");
            string fillMethod = Console.ReadLine(); //fillMethod je 1 => cisla nahodna, fillMethod neni 1 => cisla od 1 do x*y
            int fillMethodInt = 0;
            if (Int32.TryParse(fillMethod, out fillMethodInt) && Int32.Parse(fillMethod) == 1)
                fillArray(arr, x, y, 1);
            else
                fillArray(arr, x, y, 2);

            do
            {
                Console.WriteLine("0 pro transpozici matice");
                Console.WriteLine("1 pro prohozeni prvku, 2 pro prohozeni radku, 3 pro prohozeni sloupcu");
                Console.WriteLine("4 pro otoceni poradi prvku po hl. diagonale, 5 po vedl. diagonale");
                Console.WriteLine("6 pro vynasobeni matice cislem, 7 pro secteni dvou matic, 8 pro odecteni dvou matic, 9 pro nasobeni dvou matic");

                Console.WriteLine("Zadej cislo operace kterou chces provest.");
                string operationInput = Console.ReadLine();
                int operation = convertTesting(operationInput, 10); //overujeme, zda uzivatel zadal platne cislo operace

                switch (operation)
                {
                    case 0:
                        arr = transposition(arr, x, y);
                        break;
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
                    case 7:
                        Console.WriteLine("Pro operaci, kterou jsi zvolil, bude potreba vytvorit druhou matici, s niz se bude puvodni matice scitat.");
                        secondArr = createSecondArray(arr, x, y, false);
                        arr = addArrays(arr, secondArr, x, y);
                        break;
                    case 8:
                        Console.WriteLine("Pro operaci, kterou jsi zvolil, bude potreba vytvorit druhou matici, ktera se odecte od puvodni matice.");
                        secondArr = createSecondArray(arr, x, y, false);
                        arr = substractArrays(arr, secondArr, x, y);
                        break;
                    case 9:
                        Console.WriteLine("Pro operaci, kterou jsi zvolil, bude potreba vytvorit druhou matici, se kterou se puvodni matice vynasobi.");
                        secondArr = createSecondArray(arr, x, y, true);
                        arr = multiplyArrays(arr, secondArr, x, secondArr.GetLength(1)); //rozmery nove matice jsou x = pocet radku prvni matice a y = pocet sloupcu druhe matice
                        break;
                }

                Console.WriteLine("Zadej ANO (a pote zmackni Enter) pro ukonceni programu, pokud zadas cokoliv jineho, budes moct pokracovat v provadeni operaci s matici.");
            }
            while (Console.ReadLine() != "ANO");
            Console.ReadKey();
        }
    }
}
