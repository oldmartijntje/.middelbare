using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elementen = new int[10];
                for (int i = 0; i < 10; i++)
            {
                elementen[i] = i * 10 + 10;
                
            }










            Console.ReadLine();

        }
        static int CalcFor(int a)
        {
            int a = 0;
            for (int i = 0; i < 10; i++)
            {
                a = a + elementen[i];
            }



            int b = 1;
            return b;
        }
    }
}
