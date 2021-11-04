using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("wat is uw faavoorietuh spreekwoord?");
            string spreekwoord = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(spreekwoord);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("wat is uw faavoorietuh voedsell");
            string voedsell = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(voedsell);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("als je nu niet op enter klikt sluit je het programma niet af!!!");
        }
    }
}
