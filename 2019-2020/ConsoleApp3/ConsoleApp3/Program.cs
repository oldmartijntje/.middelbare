using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string p ="";
            string a = Console.ReadLine();
            int d = Convert.ToInt32(a);
            if (d < 10)
            {
                p = "kleiner";
            }
            if (d > 10)
            {
                p = "groter";
            }
            Console.WriteLine(p);
            Console.ReadLine();

        }
        
    }
}
