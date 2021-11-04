using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int wins = 0;
            int loses = 0;
            int draws = 0;
            int stupid = 0;
            int qqqq = 1;
            string BBB = "a";
            int CCC = 1;
            int rocks = 0;
            int paper = 0;
            int scissors = 0;
            int rockspc = 0;
            int paperpc = 0;
            int scissorspc = 0;
            
            
            Console.WriteLine("help: every time after 'rock... paper... scissors... shoot..' type one of the following: 'rock ' or 'paper' or 'scissors'");
            while (qqqq == 1)
            {
                CCC = 333;
                Console.WriteLine("rock... paper... scissors... shoot!");
                string antwoord = Console.ReadLine();
                int AAA = randomnumber();
                if (antwoord == "rock")
                {
                    CCC = 1;
                    rocks = rocks + 1;
                }
                else if (antwoord == "paper")
                {
                    CCC = 2;
                    paper = paper + 1;
                }
                else if (antwoord == "scissors")
                {
                    CCC = 3;
                    scissors = scissors + 1;
                }
                
                if (AAA == 1)
                {
                    
                    rockspc = rockspc + 1;
                }
                else if (AAA == 2)
                {
                    
                    paperpc = paperpc + 1;
                }
                else if (AAA == 3)
                {
                    
                    scissorspc = scissorspc + 1;
                }
                if (antwoord == "or")
                {
                    Console.WriteLine();
                    Console.WriteLine("'or' isn't a option");
                    CCC = 10;
                }
                if (CCC == AAA)
                {
                    draws = draws + 1;
                    Console.WriteLine();
                    Console.WriteLine("DRAW!");
                }
                if (CCC == 333)
                {
                    AAA = 1;
                    CCC = 3;
                }
                else if (CCC + AAA == 3)
                {
                    if (CCC > AAA)
                    {
                        wins = wins + 1;
                        Console.WriteLine();
                        Console.WriteLine("You Win!");
                    }
                    else
                    {
                        loses = loses + 1;
                        Console.WriteLine();
                        Console.WriteLine("You Lost");
                    }
                }
                else if (CCC + AAA == 4)
                {
                    if (AAA > CCC)
                    {
                        wins = wins + 1;
                        Console.WriteLine();
                        Console.WriteLine("You Win!");
                    }
                    else
                    {
                        loses = loses + 1;
                        Console.WriteLine();
                        Console.WriteLine("You Lost");
                    }
                }
                else if (CCC + AAA == 5)
                {
                    if (CCC > AAA)
                    {
                        wins = wins + 1;
                        Console.WriteLine();
                        Console.WriteLine("You Win!");
                    }
                    else
                    {
                        loses = loses + 1;
                        Console.WriteLine();
                        Console.WriteLine("You Lost");
                    }
                }
                else
                {
                    if (AAA == 1)
                    {
                        BBB = "rock";
                    }
                    else if (AAA == 2)
                    {
                        BBB = "paper";
                    }
                    else
                    {
                        BBB = "scissors";
                    }
                    Console.WriteLine("your input wasn't correct, the pc got " + BBB);
                    stupid = stupid + 1;
                }
                Console.WriteLine();
                if (stupid > 0)
                {
                    Console.WriteLine("wins: " + wins + " draws: " + draws + " loses: " + loses + " failed inputs:" + stupid);
                }
                else
                {
                    Console.WriteLine("wins: " + wins + " draws: " + draws + " loses: " + loses );
                }
                Console.WriteLine();
                Console.WriteLine("you used rocks " + rocks + " times, paper " + paper + " times, scissors " + scissors + " times");
                Console.WriteLine("the pc used rocks " + rockspc + " times, paper " + paperpc + " times, scissors " + scissorspc + " times");
                Console.WriteLine();




            }
            
            

            
            
            

        }
        static int randomnumber()
        {
            Random random = new Random();
            return random.Next(1, 4);
        }

    }
}
