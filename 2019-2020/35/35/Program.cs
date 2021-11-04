using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35
{
    class Program
    {
        static void Main(string[] args)
        {
            for (ulong i = 0; i < 999; i++)
            {
            Console.WriteLine("geef een getal");
            string d = Console.ReadLine();
            ulong e = Convert.ToUInt64(d);
            ulong c = faculteit(e);

            Console.WriteLine(e + "! = " + c);
            }
            
            
        }
        static ulong faculteit(ulong a)
        {
            ulong b = a;
            for (ulong result = 1; result < a; result++)
            {
                 b = b * result;

            }

            return b;
        }
    }
}
