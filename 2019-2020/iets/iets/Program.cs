using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("vul een getal onder de 10 in");
            string Cijfer = Console.ReadLine();
            int Cijfer1 = Convert.ToInt32(Cijfer);
            if (Cijfer1 < 0)
            {
                Console.WriteLine("je bent eigenwijs");
            }
            else if (Cijfer1 < 10)
            {
                Console.WriteLine("je bent een brave koter");
            }
            else
            {
                Console.WriteLine("je moet nog leren lezen");
            }
            Console.WriteLine("geef nog een sappig getalletje");
            string Cijfer2 = Console.ReadLine();
            int Cijfer3 = Convert.ToInt32(Cijfer2);
            int Uitkomst = (Cijfer3 + Cijfer1);
            if (Uitkomst != 5)
            {
                Console.WriteLine("5 staat voor 1+4 en 2+3 daarom is het zo geweldig, je had 5 moeten hebben als uitkomst omdat 1+4 5 is");
            }
            else
            {
                Console.WriteLine("type something to die");
            }
            Console.ReadLine();
        }
    }
}
