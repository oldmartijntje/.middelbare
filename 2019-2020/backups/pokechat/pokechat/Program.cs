using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int activepokemon = 1;
            int startgame = 1;
            int wasteurtime = 0;
            int AAAAAA = 1;
            int[] healthpokemon = new int[] { 0, 200, 0,0};
            int[] move1 = new int[6];
            int[] move2 = new int[6];
            int[] move3 = new int[6];
            int[] move4 = new int[6];
            
            string[] starter = new string[] {"charmander","squirtle","bulbasaur"};
            //1=grass,2=fire,3=water,4=bug,5=flying,6=normal,7=poison,8=electric,9=ground,10=ice
            //fire<water,ice<fire,water<electric,grass<fire
            int[] pokemontype = new int[] { 0, 1, 1,1,2,2,2,3,3,3,4,4,4,4,4,4,5,5,5,6,6,5,5,7,7,8,8,9,9 };
            string[] pokemonnames = new string[] {"", "bulbasaur", "ivosaur", "venusaur", "charmander", "charmeleon", "charizard", "squirtle", "wartortle", "blastoise", "caterpie", "metapod", "butterfree", "weedle", "kakuna", "beedrill", "pidgey", "pidgeotto", "pidgeot", "rattata", "raticate", "spearow", "fearow", "ekans", "arbok", "pikachu", "raichu", "sandshrew", "sandslash"};
            string[] moves = new string[] { "", "tackle", "scratch", "watergun", "ember" };
            int[] movedamage = new int[] { 0 ,35 ,40 ,40 , 40};
            int[] movestype = new int[] { 0,6,6,3,2 };
            int[] starterchoose = new int[3];
            int[] yourdesk = new int[3];
            for (int i = 0; i < 3; i++)
            {
                if (starter[i] == "charmander")
                {
                    starterchoose[i] = 4;
                }
                else if (starter[i] == "squirtle")
                {
                    starterchoose[i] = 7;
                }
                else if (starter[i] == "bulbasaur")
                {
                    starterchoose[i] = 1;
                }
                else if (starter[i] == "ivysaur")
                {
                    starterchoose[i] = 2;
                }
                else if (starter[i] == "venusaur")
                {
                    starterchoose[i] = 3;
                }
                else if (starter[i] == "charmeleon")
                {
                    starterchoose[i] = 5;
                }
                else if (starter[i] == "charizard")
                {
                    starterchoose[i] = 6;
                }
                else if (starter[i] == "wartortle")
                {
                    starterchoose[i] = 8;
                }
                else if (starter[i] == "blastoise")
                {
                    starterchoose[i] = 9;
                }
            }
            //giving test moves
            move1[1] = 1;
            move2[1] = 2;
            move3[1] = 3;
            move4[1] = 4;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("welcome to pokeconsole");
            for (int i = 0; i < i + startgame; i++)
            {
                Console.WriteLine("Choose your starter");
                Console.WriteLine("press 1 for " + starter[0] + " press 2 for " + starter[1] + " press 3 for " + starter[2]);
                string AAA = Console.ReadLine();
                
                if (AAA == "1")
                {
                    yourdesk[0] = starterchoose[0];
                    startgame = 0;
                    Console.WriteLine("You got your starter pokemon! it's " + starter[0] + "!");
                    
                }
                else if (AAA == "2")
                {
                    yourdesk[0] = starterchoose[1];
                    startgame = 0;
                    Console.WriteLine("You got your starter pokemon! it's " + starter[1] + "!");
                }
                else if (AAA == "3")
                {
                    yourdesk[0] = starterchoose[2];
                    startgame = 0;
                    Console.WriteLine("You got your starter pokemon! it's " + starter[2] + "!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("oops, something went wrong, please try again");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            Console.WriteLine();
            Console.WriteLine("lets go!");
            
            for (int a = 0; a < a + AAAAAA; a++)
            {
                
                int AAC = randomnumber();
                if (AAC == 0)
                {
                    
                    
                    Console.WriteLine("a wild pokemon appeared!");
                    int AAE = 0;
                    for (int i = 0; i < 20; i++)
                    {
                        AAE = AAE + 1;
                    }
                    Console.WriteLine("your HP: " + healthpokemon[activepokemon]);
                    int AAH = randomnumberencounterpokemon();
                    int AAG = AAH;
                    Console.WriteLine("it's " + pokemonnames[AAG] + "!");
                    Console.WriteLine(AAG);
                   
                    int healthwildpokemon = health() * 12;
                    Console.WriteLine("it's HP = " + healthwildpokemon);

                    int AAO = 1;
                    for (int AAP = 0; AAP < AAP + AAO; AAP++)
                    {
                        
                        Attackwild();
                        string AAI = Console.ReadLine();
                        int AAJ = Convert.ToInt32(AAI);
                        if (AAJ == 1)
                        {
                            int AAL = Attack(move1, move2, move3, move4, activepokemon, movedamage,movestype,pokemontype, moves, AAG);
                            if (AAL == 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("the attack missed");
                            }
                            else
                            {
                                
                                healthwildpokemon -= AAL;
                                if (AAL > 60)
                                {
                                    Console.WriteLine("it was very effective");
                                }
                                else
                                {
                                    Console.WriteLine("it wasn't very effective");
                                }
                                Console.WriteLine();
                                Console.WriteLine("his HP is brought down to " + healthwildpokemon);
                            }
                        }

                        //pokemontype[AAG]
                        if (healthwildpokemon > 0)
                        {
                            int QQQQQQQQQ = 0;
                            int AAR = randommove();
                            
                            Console.ReadLine();
                            Console.WriteLine("the attacker used " + moves[AAR]);
                            int AAQ = attackopponent( movedamage, AAR);
                            if (AAQ == 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("the attack missed");
                            }
                            else
                            {
                                healthpokemon[activepokemon] -= AAQ;
                                if (AAQ > 60)
                                {
                                    Console.WriteLine("it was very effective");
                                }
                                else
                                {
                                    Console.WriteLine("it wasn't very effective");
                                }
                                Console.WriteLine();
                                Console.WriteLine("your HP is brought down to " + healthpokemon[activepokemon]);
                            }
                        }
                        

                        Console.ReadLine();
                        if (healthwildpokemon < 0)
                        {
                            AAO = 0;
                            Console.WriteLine("you won!");
                            Console.WriteLine();
                            Console.ReadLine();
                        }
                        else if (healthpokemon[activepokemon] < 0)
                        {
                            Console.WriteLine("your pokemon died");
                            AAO = 0;
                            Console.WriteLine("you lost");
                            Console.WriteLine();
                            Console.ReadLine();
                        }
                        healthpokemon[activepokemon] = 200;

                        /*if (healthpokemon2 < 0)
                        {
                            
                        }
                        if (healthpokemon3 < 0)
                        {
                            
                        }
                        if (healthpokemon4 < 0)
                        {
                           
                        }
                        if (healthpokemon5 < 0)
                        {
                            
                        }
                        if (healthpokemon6 < 0)
                        {
                            
                        }*/
                    }
                    AAO = 1;   
                    
                    
                }
            }
            Console.ReadLine();
            





        }
        static int randomnumber()
        {
            Random random = new Random();
            return random.Next(0, 10);
        }
        static int randommove()
        {
            Random random = new Random();
            return random.Next(1, 5);
        }
        static int randomnumber2(int A)
        {
            int AA = A + 1;
            int AB = A + 40;
            Random random = new Random();
            return random.Next(AA, AB);
        }
        static int attackopponent(int[] movedamage, int AAR)
        {
            
            int AD = randomnumber();
            if (AD == 2)
            {
                return 0;
            }
            else
            {
                int AC = randomnumber2(movedamage[AAR]);
                return AC;
            }

        }
        static int randomnumberencounterpokemon()
        {
            Random random2 = new Random();
            return random2.Next(1, 29);
        }
        static void Attackwild()
        {
            Console.WriteLine();
            Console.WriteLine("what do you want to do?");
            Console.WriteLine("press 1 to attack, 2 to run, 3 to switch pokemon, 4 to catch pokemon");
            Console.WriteLine();
        }
        static int health()
        {
            Random random2 = new Random();
            return random2.Next(10, 290);
        }
        static int Attack(int[] move1, int[] move2, int[] move3, int[] move4, int AAK, int[] movedamage,int[] movestype, int[] pokemontype, string[] moves, int AAG)
        {
            int inplaceholder = 1;
            int damage = 0;
            
            for (int i = 0; i < i + inplaceholder; i++)
            {
                Console.WriteLine("what move?");
                Console.WriteLine("press 1 for: " + moves[move1[AAK]] + ", press 2 for: " + moves[move2[AAK]] + ", press 3 for: " + moves[move3[AAK]] + ", press 4 for: " + moves[move4[AAK]]);
                string AAM = Console.ReadLine();
                if (AAM == "1")
                {

                }
            }
            int AAN = Convert.ToInt32(AAM);
            int miss = randomnumber();
            int AAR = movedamage[AAN];
            if (miss == 3)
            {

                return damage;
            }
            
            else
            {
                if (AAN == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("You used " + moves[move1[AAK]]);
                    Console.WriteLine();
                    if (movestype[move1[AAK]] == 3)
                    {
                        if (pokemontype[AAG] == 2)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move1[AAK]] == 2)
                    {
                        if (pokemontype[AAG] == 10)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move1[AAK]] == 8)
                    {
                        if (pokemontype[AAG] == 3)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move1[AAK]] == 2)
                    {
                        if (pokemontype[AAG] == 1)
                        {
                            AAR = AAR + 20;
                        }
                    }
                }
                else if (AAN == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("You used " + moves[move2[AAK]]);
                    Console.WriteLine();
                    if (movestype[move2[AAK]] == 3)
                    {
                        if (pokemontype[AAG] == 2)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move2[AAK]] == 2)
                    {
                        if (pokemontype[AAG] == 10)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move2[AAK]] == 8)
                    {
                        if (pokemontype[AAG] == 3)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move2[AAK]] == 2)
                    {
                        if (pokemontype[AAG] == 1)
                        {
                            AAR = AAR + 20;
                        }
                    }
                }
                else if (AAN == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("You used " + moves[move3[AAK]]);
                    Console.WriteLine();
                    if (movestype[move3[AAK]] == 3)
                    {
                        if (pokemontype[AAG] == 2)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move3[AAK]] == 2)
                    {
                        if (pokemontype[AAG] == 10)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move3[AAK]] == 8)
                    {
                        if (pokemontype[AAG] == 3)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move3[AAK]] == 2)
                    {
                        if (pokemontype[AAG] == 1)
                        {
                            AAR = AAR + 20;
                        }
                    }
                }
                else if (AAN == 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("You used " + moves[move4[AAK]]);
                    Console.WriteLine();
                    if (movestype[move4[AAK]] == 3)
                    {
                        if (pokemontype[AAG] == 2)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move4[AAK]] == 2)
                    {
                        if (pokemontype[AAG] == 10)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move4[AAK]] == 8)
                    {
                        if (pokemontype[AAG] == 3)
                        {
                            AAR = AAR + 20;
                        }
                    }
                    else if (movestype[move4[AAK]] == 2)
                    {
                        if (pokemontype[AAG] == 1)
                        {
                            AAR = AAR + 20;
                        }
                    }
                }
            }


            


                int damagerandom = randomnumber2(AAR);
                return damagerandom;
            
        }

    }
}
