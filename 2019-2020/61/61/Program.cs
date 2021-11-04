using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _61
{
    class Program
    {
        static void Main(string[] args)
        {
            WhileLoop(-375,2147483647);
            
            Console.ReadLine();
        }
        /// <summary>
        /// Continue in while-loop until index is equal to 10.
        /// </summary>
        /// <param name="Cijfer1">the number where it begins from</param>
        /// <param name="Cijfer2">the number where the first number counts up to</param>
        static void WhileLoop(int Cijfer1, int Cijfer2)
        {
            while (Cijfer1 < Cijfer2)
            {
                Console.Write("While statement ");
                // Write the index to the screen.
                Console.WriteLine(Cijfer1);
                // Increment the variable.
                Cijfer1++;


            }
        }
    }
}
