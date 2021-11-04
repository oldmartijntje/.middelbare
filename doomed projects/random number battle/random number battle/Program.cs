using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_number_battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int nuuumer = 0;
            int Try = 0;
            int Nummer = 3;
            Console.WriteLine("uitleg: je moet elke keer een nummmer intoetsen, als je het goede nummer hebt wordt de mogelijkheid minder, bij een fout antwoord meer. zorg ervoor dat je niet te vaak fout gokt want dan is de kans klein dat je terug komt en wint");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            while (Nummer != 0)
            {
                
                Try = Try + 1;
                Console.WriteLine("beurt: " + Try);
                Console.WriteLine("kies een nummer tussen 1 en " + Nummer + " en toets het in");
                
                int Randomnummertie = randomnumber(1, Nummer + 1);
                
                string Antwoord = Console.ReadLine();
                int Antwoord1 = Convert.ToInt32(Antwoord);
                
                if (Antwoord1 > Nummer)
                {
                    Console.WriteLine("je hebt een groter getal gezegd dan waar je keuze uit had, das pech, een punt verspild");
                }
                if (Randomnummertie == Antwoord1)
                {
                    nuuumer = Nummer;
                    Nummer = Nummer - 1;
                    Console.WriteLine("goedzo, keuze is veranderd naar " + Nummer + " in plaats van " + nuuumer);

                }
                else if (Nummer > 4)
                {
                    Console.WriteLine("je krijgt nog een kans");
                    Console.WriteLine("kies een nummer tussen 1 en " + Nummer + " en toets het in");
                    string Antwoord2 = Console.ReadLine();
                    int Antwoord3 = Convert.ToInt32(Antwoord2);
                    if (Antwoord3 > Nummer)
                    {
                        Console.WriteLine("je hebt een groter getal gezegd dan waar je keuze uit had, das pech, een punt verspild");
                    }
                    if (Randomnummertie == Antwoord3)
                    {
                        nuuumer = Nummer;
                        Nummer = Nummer - 1;
                        Console.WriteLine("goedzo, keuze is veranderd naar " + Nummer + " in plaats van " + nuuumer);
                    }
                    else if (Nummer > 6)
                    {
                        Console.WriteLine("je krijgt nog een kans");
                        Console.WriteLine("kies een nummer tussen 1 en " + Nummer + " en toets het in");
                        string Antwoord4 = Console.ReadLine();
                        int Antwoord5 = Convert.ToInt32(Antwoord4);
                        if (Antwoord5 > Nummer)
                        {
                            Console.WriteLine("je hebt een groter getal gezegd dan waar je keuze uit had, das pech, een punt verspild");
                        }
                        if (Randomnummertie == Antwoord5)
                        {
                            nuuumer = Nummer;
                            Nummer = Nummer - 1;
                            Console.WriteLine("goedzo, keuze is veranderd naar " + Nummer + " in plaats van " + nuuumer);
                        }
                        else if (Nummer > 8)
                        {
                            Console.WriteLine("je krijgt nog een kans");
                            Console.WriteLine("kies een nummer tussen 1 en " + Nummer + " en toets het in");
                            string Antwoord7 = Console.ReadLine();
                            int Antwoord6 = Convert.ToInt32(Antwoord7);
                            if (Antwoord6 > Nummer)
                            {
                                Console.WriteLine("je hebt een groter getal gezegd dan waar je keuze uit had, das pech, een punt verspild");
                            }
                            if (Randomnummertie == Antwoord6)
                            {
                                nuuumer = Nummer;
                                Nummer = Nummer - 1;
                                Console.WriteLine("goedzo, keuze is veranderd naar " + Nummer + " in plaats van " + nuuumer);
                            }
                            else if (Nummer > 10)
                            {
                                Console.WriteLine("je krijgt nog een kans");
                                Console.WriteLine("kies een nummer tussen 1 en " + Nummer + " en toets het in");
                                string Antwoord8 = Console.ReadLine();
                                int Antwoord9 = Convert.ToInt32(Antwoord8);
                                if (Antwoord9 > Nummer)
                                {
                                    Console.WriteLine("je hebt een groter getal gezegd dan waar je keuze uit had, das pech, een punt verspild");
                                }
                                if (Randomnummertie == Antwoord9)
                                {
                                    nuuumer = Nummer;
                                    Nummer = Nummer - 1;
                                    Console.WriteLine("goedzo, keuze is veranderd naar " + Nummer + " in plaats van " + nuuumer);
                                }
                                else
                                {
                                    Console.WriteLine("wat jammer nou, je hebt het weer fout, dat betekent dat er een extra mogelijkheid bij komt");
                                    Nummer = Nummer + 1;

                                }

                            }
                            else
                            {
                                Console.WriteLine("wat jammer nou, je hebt het weer fout, dat betekent dat er een extra mogelijkheid bij komt");
                                Nummer = Nummer + 1;

                            }

                        }
                        else
                        {
                            Console.WriteLine("wat jammer nou, je hebt het weer fout, dat betekent dat er een extra mogelijkheid bij komt");
                            Nummer = Nummer + 1;

                        }

                    }
                    else
                    {
                        Console.WriteLine("wat jammer nou, je hebt het weer fout, dat betekent dat er een extra mogelijkheid bij komt");
                        Nummer = Nummer + 1;

                    }

                }
                else
                {
                    Console.WriteLine("wat jammer nou, je hebt het fout, dat betekent dat er een extra mogelijkheid bij komt");
                    Nummer = Nummer + 1;
                }
                
            }
            Console.WriteLine("Gefeliciteerd, je hebt gewonnen!!!");
            Console.ReadLine();


        }
        static int randomnumber(int a, int b)
        {
            Random random = new Random();
            return random.Next(a, b);
        }
    }
}
