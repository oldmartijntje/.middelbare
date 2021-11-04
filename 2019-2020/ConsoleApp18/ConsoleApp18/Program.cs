using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int samenvoegen = 0;
            int[] getal = new int[100];
            for (int i = 0; i < 100; i++)
            {
                getal[i] = (i + 1) * 2;
                
            }
            foreach (int number in getal)
            {
                
                Console.WriteLine(getal[count]);
                if (count != 99)
                {
                    Console.WriteLine("+");
                }
                
                samenvoegen = samenvoegen + getal[count];
                count++;
            }
            Console.WriteLine("= " + samenvoegen);
            Console.ReadLine();
        }
    }
}
