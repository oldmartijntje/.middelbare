using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAYYNESSSSSSSSSSSSSSSSSSSS
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "=";
            
            int GGG = 1;
            for (int i = 0; i < i + GGG; i++)
            {
                string A = "8";

                Console.WriteLine("who do you want to test?");
                string naam = Console.ReadLine();
                int Q = RandomNumber(1, 10);
                if (Q == 3)
                {
                    Console.WriteLine(naam + " has no dick");
                }
                else if (Q == 2)
                {
                    Console.WriteLine(naam + " his dick has fallen off when he mastrubated");
                }
                else if (Q == 8)
                {
                    Console.WriteLine(naam + " his dick got removed");
                }
                else
                {
                    for (int SS = 0; SS < Q; SS++)
                    {
                        A = A + S;
                    }
                    A = A + ">";
                    Console.WriteLine(naam + "'s dick looks like this: " + A);
                    
                }
                Console.WriteLine("wanna see if " + naam + " is gay?");
                Console.ReadLine();
                Console.WriteLine();
                int AAAAA = RandomNumber2(1, 5);
                if (AAAAA == 3)
                {
                    Console.WriteLine(naam + " is gay");
                }
                else if (AAAAA == 4)
                {
                    Console.WriteLine(naam + " is Bisexual");
                }
                else
                {
                    Console.WriteLine(naam + " is not gay");
                }

                Console.WriteLine();

            }
            
        }
         
        static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        static int RandomNumber2(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
