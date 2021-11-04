using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            float w = 0;
            float q = 0;
            float[] elementen = new float[10];
            elementen[0] = 6.60f;
            elementen[1] = 6.95f;
            elementen[2] = 6.36f;
            elementen[3] = 7.60f;
            elementen[4] = 7.46f;
            elementen[5] = 6.58f;
            elementen[6] = 6.28f;
            elementen[7] = 8f;
            elementen[8] = 7.00f;
            elementen[9] = 6.88f;
            Console.WriteLine("de boodschap: dat je met dit soort cijfers: " + elementen[5] + " tot de top van Nederland behoort.");
            for (int i = 0; i < 5; i++)
            {
                w = elementen[i + 4] + w;
            }
            Console.WriteLine(w / 5 + " is het gemiddelde van je laaaaaaatste cijfers, het gaat niet zo best zo te zien ._."); 
            foreach (float s in elementen)
            {
                q = s + q;
            }
            Console.WriteLine(q / 10 + " is het gemiddelde");
            Console.ReadLine();
        }
    }
}
