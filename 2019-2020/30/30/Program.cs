using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {
            Console.WriteLine("geef een cijfuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuur");
            string Cijfer = Console.ReadLine();
            float Cijfer3 = Convert.ToSingle(Cijfer);
            KeerDrie(Cijfer3); 
            }
            
            


            Console.ReadLine();

        }
        static void KeerDrie(float Cijfer3) 
        {
            Console.WriteLine((Cijfer3 * 3) + " is een geniaal getal, niet " + Cijfer3 + "!");
        }
        
    }

}
