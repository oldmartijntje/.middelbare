using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getal?????");
            int deler = Convert.ToInt32(Console.ReadLine());
            int uitkomst = ExcpectationTest(deler);
            Console.WriteLine(deler + " gedeeld door 100 is " + uitkomst);
        }
        private static int ExcpectationTest(int deler)
        {
            StreamReader sr = null;
            try
            {
                int uitkomst = 100 / deler;
                return uitkomst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

    }
}
