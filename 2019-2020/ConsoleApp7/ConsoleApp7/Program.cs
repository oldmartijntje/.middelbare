using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("geef de diameter, dan bereken ik de inhoud van je bol");
            string diameter = Console.ReadLine();
            double Diameter = Convert.ToSingle(diameter);
            double Straal = Diameter * 0.5;
            double Uitkomst1 = Straal * Straal * Straal * 3.14159265359;
            double Uitkomst2 = Uitkomst1 * 4 / 3;
            
            Console.WriteLine("de inhoud is: " + Uitkomst2);
            Console.ReadLine();

        }
    }
}
