using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Getal = new int[100];
           int b = 0;
            for (int i = 0; i < 100; i++)
            {
                
                Getal[i] = (i + 1) * 2;
                b = b + Getal[i];
                Console.WriteLine(Getal[i]);
                Console.WriteLine("+");


            }
            Console.WriteLine("= " + b);
            Console.ReadLine();
        }
    }
}
