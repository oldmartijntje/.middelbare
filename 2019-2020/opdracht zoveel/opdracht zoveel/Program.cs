using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht_zoveel
{
    class Program
    {
        static void Main(string[] args)
        {
            Start: 
            Console.WriteLine("vul een getalletje in");
            string Getal = Console.ReadLine();
            int Cijfer = Convert.ToInt32(Getal);
            int Getal2 = Cijfer * 50;
            int Getal3 = Getal2 + 111;
            int Getal4 = Getal3 * 50;
            Console.WriteLine(Getal4);
            if (Getal4 > 100000)
            {
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("beveiligingscode met meer cijfers is aangeraden");
                goto Start;
            }

        }
    }
}
