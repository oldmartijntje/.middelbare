using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht_10
{
    class Program
    {
        static void Main(string[] args)
        {
        Start:
            Console.WriteLine("geef een getal met 2 decimalen(als je een commagetal wilt, gebruik een comma en geen punt)");
            string Cijfer = Console.ReadLine();
            float CijferFloat = Convert.ToSingle(Cijfer);
            if (CijferFloat > 99)
            {
                goto Start;
            }
            if (CijferFloat < 10)
            {
                goto Start;
            }
            if (CijferFloat < 50)
            {
                int CijferInt = Convert.ToInt32(CijferFloat);
                Console.WriteLine("het is " + CijferInt);
            }
            else
            {
                Console.WriteLine("het is " + CijferFloat);
            }
            Console.ReadLine();
        }
    }
}
