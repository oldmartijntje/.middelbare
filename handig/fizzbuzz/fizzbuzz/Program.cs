using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("uitleg: als een nummer deelbaar is door 3 staat er fizz");
            Console.WriteLine("uitleg: als een nummer deelbaar is door 5 staat er buzz");
            Console.WriteLine("uitleg: als een nummer deelbaar is door 14 staat er bazz");
            Console.WriteLine("uitleg: als een nummer deelbaar is door 69 staat er kezz");
            Console.WriteLine("uitleg: als een nummer deelbaar is door 3 en 5 staat er fizzbuzz");
            Console.WriteLine("enzovoort");
            Console.WriteLine("als het door geen van de vier deelbaar is zie je het cijfer");
            Console.WriteLine("klik enter om te starten");
            Console.ReadLine();
            Console.WriteLine("waar moet het starten? (geen comma of min getal!)");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("waar moet het eindigen? (geen comma of min getal, en hoger dan startgetal!)");
            int eind = Convert.ToInt32(Console.ReadLine());
            int einde = eind - start;
            Console.WriteLine();
            int[] fizzbuzz = new int[] {0,0,0,0};
            for (int i = 0; i < einde; i++)
            {
                int getal = i + start;
                fizzbuzz[0] = 0;
                fizzbuzz[1] = 0;
                fizzbuzz[2] = 0;
                fizzbuzz[3] = 0;
                if (getal % 3 == 0)
                {
                    
                    fizzbuzz[0] = 1;
                }
                if (getal % 5 == 0)
                {
                    fizzbuzz[1] = 1;
                }
                if (getal % 14 == 0)
                {
                    fizzbuzz[2] = 1;
                }
                if (getal % 69 == 0)
                {
                    fizzbuzz[3] = 1;
                }
                
                
              
                if (fizzbuzz[0] == 1)
                {
                    if (fizzbuzz[1] == 1)
                    {
                        if (fizzbuzz[2] == 1)
                        {
                            if (fizzbuzz[3] == 1)
                            {
                                Console.WriteLine("fizzbuzzbazzkezz" + getal);
                            }
                            else
                            {
                                Console.WriteLine("fizzbuzzbazz");
                            }
                        }
                        else
                        {
                            if (fizzbuzz[3] == 1)
                            {
                                Console.WriteLine("fizzbuzzkezz");
                            }
                            else
                            {
                                Console.WriteLine("fizzbuzz");
                            }
                        }
                    }
                    else
                    {
                        if (fizzbuzz[2] == 1)
                        {
                            if (fizzbuzz[3] == 1)
                            {
                                Console.WriteLine("fizzbazzkezz");
                            }
                            else
                            {
                                Console.WriteLine("fizzbazz");
                            }
                        }
                        else
                        {
                            if (fizzbuzz[3] == 1)
                            {
                                Console.WriteLine("fizzkezz");
                            }
                            else
                            {
                                Console.WriteLine("fizz");
                            }
                        }
                    }
                }
                else
                {
                    if (fizzbuzz[1] == 1)
                    {
                        if (fizzbuzz[2] == 1)
                        {
                            if (fizzbuzz[3] == 1)
                            {
                                Console.WriteLine("buzzbazzkezz");
                            }
                            else
                            {
                                Console.WriteLine("buzzbazz");
                            }
                        }
                        else
                        {
                            if (fizzbuzz[3] == 1)
                            {
                                Console.WriteLine("buzzkezz");
                            }
                            else
                            {
                                Console.WriteLine("buzz");
                            }
                        }
                    }
                    else
                    {
                        if (fizzbuzz[2] == 1)
                        {
                            if (fizzbuzz[3] == 1)
                            {
                               Console.WriteLine("bazzkezz");
                            }
                            else
                            {
                                Console.WriteLine("bazz");
                            }
                        }
                        else
                        {
                            if (fizzbuzz[3] == 1)
                            {
                                Console.WriteLine("kezz");
                            }
                            else
                            {
                               Console.WriteLine(getal);
                            }
                        }
                    }
                }

            }
            Console.ReadLine();
        }
    }
}
