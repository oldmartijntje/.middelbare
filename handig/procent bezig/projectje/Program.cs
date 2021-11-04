
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectje
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; ++i)
            {
                Console.Write("\r{0}%   ", i);
                
            }
            string line = "";

            for (int i = 0; i < 100; i++)
            {
                string backup = new string('\b', line.Length);
                Console.Write(backup);
                line = string.Format("{0}%", i);
                Console.Write(line);
            }
            Console.ReadLine();

        }
    }
}
