using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int q = 1; q < 6; q++)
            {
                schrijfTafel(q * 2);
            }
            Console.ReadLine();
        }
        static void schrijfTafel(int tafel)
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine(i + " keer " + tafel + " is: " + (tafel * i));
            }
        }
    }
}
