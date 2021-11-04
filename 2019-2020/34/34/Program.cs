using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("voer een HEEL getal in");
            string e = Console.ReadLine();
            int a = Convert.ToInt32(e);
            Console.WriteLine("voer nog een HEEL getal in");
            string f = Console.ReadLine();
            int b = Convert.ToInt32(f);
            int d = vermenigvuldig(a, b);
            Console.WriteLine(a + " maal " + b + " is: " + d);
            Console.ReadLine();
        }
        static int vermenigvuldig(int a, int b)
        {
            int c = a * b;
            return c;
        }
    }
}
