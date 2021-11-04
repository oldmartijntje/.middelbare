using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("voer een getal in");
            string Cijfer = Console.ReadLine();
            int Cijfer2 = Convert.ToInt32(Cijfer);
            for (int Q = 0; Q < 31; Q++)
            {
                Console.WriteLine(Q + " keer " + Cijfer2 + " is " + Q * Cijfer2);
            }
            Console.ReadLine();
        }
    }
}
