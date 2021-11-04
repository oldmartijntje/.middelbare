using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hoeveel uur slaapt u per nacht????");
            string Slaap = Console.ReadLine();
            int Henk = Convert.ToInt32(Slaap);
            if (Henk > 7) {
                Console.WriteLine("wauw, u bent echt een wonderkind");
            }
            else {
                Console.WriteLine("get some toxic and you will sleep longer");
            }
            

            Console.ReadLine();
        }
    }
}
