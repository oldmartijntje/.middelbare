using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("wat is jouw geweldige naam?");
            string naampie = Console.ReadLine();
            Console.WriteLine("hoe heet het beste mens op aarde?");
            string beste_naam = Console.ReadLine();
            Console.WriteLine("dus jullie heten: " + naampie + " en " + beste_naam);
            Console.WriteLine("wat is jouw geweldige leeftijd?");
            string leeftijd = Console.ReadLine();
            Console.WriteLine("wat is de leeftijd van het beste mens op aarde?");
            string beste_leeftijd = Console.ReadLine();
            Console.WriteLine("dus jullie krijgen samen " + leeftijd + beste_leeftijd + " kinderen");
        }
    }
}
