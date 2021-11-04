using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _60
{
    class Program
    {
        static void Main(string[] args)
        {
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("vul een getal onder de 10 in");
                int getal1 = Convert.ToInt32(Console.ReadLine());
                if (getal1 > 10)
                {
                    Console.WriteLine("je hebt het fout gedaan, de code begint opnieuw");
                    continue;                  
                }
                Console.WriteLine("vul een getal onder de 20 in");
                int getal2 = Convert.ToInt32(Console.ReadLine());
                if (getal2 > 20)
                {
                    Console.WriteLine("je hebt het fout gedaan, de code wordt beeindigd");
                    break;
                }
                Console.WriteLine("je hebt het goed gedaan, je mag nog een keer");
            }
            

            Console.ReadLine();
        }
    }
}
