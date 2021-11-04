using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _43
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] woordGetallen = new string[] {"nulde","eerste", "tweede", "derde", "virde", "vijfde", "zesde", "zevende", "achtste", "negende", "tiende", };
            float a = 0;
            float[] elementen = new float[10];
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("vul een getal in!!!!!!!!");
                elementen[i] = Convert.ToSingle(Console.ReadLine());
            }
            

            
            
            
            for (int i = 1; i < 11; i++)
            {
                a = elementen[i-1] + a;
                Console.WriteLine("tot en met het " + woordGetallen[i] + " getal is het gemiddelde " + a / i);
            }
            
            Console.ReadLine();
        }
    }
}
