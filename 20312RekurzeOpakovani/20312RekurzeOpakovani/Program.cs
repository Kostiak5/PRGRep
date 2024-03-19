using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20312RekurzeOpakovani
{
    internal class Program
    {
        static int Fib(int n)
        {
            if (n == 0 || n == 1) { return n; }
            return Fib(n - 1) + Fib(n - 2);
        }
        static int Rec(int n)
        {
            if(n == 1) { return 1; }
            int res = n * Rec(n - 1);
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Fib(2));
            Console.ReadKey();
        }
    }
}
