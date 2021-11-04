using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace priemgetal_berekenen
{
    class Program
    {
        static void Main(string[] args)
        {
            int loop = 0;
            int uitslag = 0;
            int auto = 0;
            Console.WriteLine("automatisch getallen checken??");
            string automatisch = Console.ReadLine();
            if (automatisch == "ja")
            {
                auto = 1;
            }
            if (auto == 0)
            {
                Console.WriteLine("welk getal wil je testen? (geen min en comma getallen)");
                
                int tester = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < tester - 1; i++)
                {
                    if (i == 0)
                    {

                    }
                    else if (i == 1)
                    {

                    }
                    else if (tester % i == 0)
                    {
                        uitslag = 1;
                    }
                }
                if (uitslag == 0)
                {
                    Console.WriteLine(tester + " is een priemgetal");
                }
                else
                {
                    Console.WriteLine(tester + " is geen priemgetal");
                }
            }
            else
            {
                Console.WriteLine("hoelang blijven testen?");
                int lengte = Convert.ToInt32(Console.ReadLine());
                for (int tester = 1; tester < lengte + 1; tester++)
                {
                    loop = loop + 1;
                    if (loop == 1000)
                    {
                        Console.WriteLine();
                        Console.WriteLine("klick om verder te gaan");
                        Console.ReadLine();
                        loop = 0;
                    }
                    for (int j = 0; j < tester - 1; j++)
                    {
                        if (j == 0)
                        {




                        }
                        else if (j == 1)
                        {

                        }
                        else if (tester % j == 0)
                        {
                            uitslag = 1;
                        }
                    }
                    if (uitslag == 0)
                    {
                        Console.WriteLine("-----=" +tester + " is een priemgetal=-----");
                    }
                    else
                    {
                        Console.WriteLine(tester + " is geen priemgetal");
                    }
                    uitslag = 0;
                    
                    
                }
            }
            
            
            Console.ReadLine();
        }
    }
}
