using System;
namespace nameOfProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int count2 = 0;
            int stop2 = 0;
            int count = 0;
            int stop = 0;
            string command = "--";
            int[] coordinatesRowMinus1 = new int[] { 1,1,1,1,1,1,1,1,1 };
            int[] coordinatesRow0 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] coordinatesRow1 = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 0 };
            int[] coordinatesRow2 = new int[] { 0, 0, 1, 0, 1, 2, 1, 1, 0 };
            int[] coordinatesRow3 = new int[] { 1, 0, 0, 0, 1, 0, 1, 0, 0 };
            int[] coordinatesRow4 = new int[] { 0, 1, 0, 1, 1, 0, 1, 0, 1 };
            int[] coordinatesRow5 = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 1 };
            int[] coordinatesRow6 = new int[] { 1, 0, 1, 1, 0, 1, 1, 1, 1 };
            int[] coordinatesRow7 = new int[] { 1, 0, 0, 1, 0, 0, 0, 1, 3 };
            int[] coordinatesRow8 = new int[] { 1, 1, 0, 0, 0, 0, 0, 0, 0 };
            int[] coordinatesRow9 = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] coordinatesPlayer = new int[] {5,2 };
            Console.WriteLine("0 = path, 1 = wall, 2 = you(the player) 3 = the goal");
            Console.WriteLine("use the commands Up(), Down(), Left(), Right() and Exit.Maze()");
            Console.WriteLine("you need to do Exit.Maze() when you are at the exit of the maze (3)");
            Console.WriteLine("there is a limit, 100 commands per level");
            Console.WriteLine("do: Play() to test it");
            Console.WriteLine("do Exit.Game to close the program");
            Console.WriteLine("");
            Console.WriteLine("//type something to continue//");
            Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("110000000");
            Console.WriteLine("100100013");
            Console.WriteLine("101101111");
            Console.WriteLine("000100001");
            Console.WriteLine("010110101");
            Console.WriteLine("100010100");
            Console.WriteLine("001012110");
            Console.WriteLine("011111110");
            Console.WriteLine("000000000");

            string[] commands = new string[100];
            while (stop2 == 0)
            {
                count = count + 1;
                count2 = count;

                stop = 1;
                while (stop == 1)
                {
                    
                    command = Console.ReadLine();
                    if (command == "Up()")
                    {
                        commands[count2] = command;
                        stop = 0;
                    }
                    else if (command == "Down()")
                    {
                        commands[count2] = command;
                        stop = 0;
                    }
                    else if (command == "Left()")
                    {
                        commands[count2] = command;
                        stop = 0;
                    }
                    else if (command == "Right()")
                    {
                        commands[count2] = command;
                        stop = 0;
                    }
                    else if (command == "Play()")
                    {
                        
                        stop = 0;
                        count = 100;
                    }
                    else if (command == "Exit.Game()")
                    {
                        
                        Environment.Exit(1);
                    }
                    else if (command == "Exit.Maze()") 
                    {
                        
                        commands[count2] = command;
                        stop = 0;
                    }
                    else
                    {
                        Console.WriteLine("that isn't a command, please try again");
                    }
                    if (count == 100)
                    {
                        stop2 = 1;
                    }
                }
                for (int i = 0; i < count2; i++)
                {
                    if (coordinatesPlayer[1] == 0)
                    {
                        CheckCoardinates(coordinatesPlayer,coordinatesRow0,coordinatesRow1,coordinatesRowMinus1);
                    }
                    else if (coordinatesPlayer[1] == 1)
                    {
                        CheckCoardinates(coordinatesPlayer, coordinatesRow1, coordinatesRow2, coordinatesRow0);
                    }
                    else if (coordinatesPlayer[1] == 2)
                    {
                        CheckCoardinates(coordinatesPlayer, coordinatesRow2, coordinatesRow3, coordinatesRow1);
                    }
                    else if (coordinatesPlayer[1] == 3)
                    {
                        CheckCoardinates(coordinatesPlayer, coordinatesRow3, coordinatesRow4, coordinatesRow2);
                    }
                    else if (coordinatesPlayer[1] == 4)
                    {
                        CheckCoardinates(coordinatesPlayer, coordinatesRow4, coordinatesRow5, coordinatesRow3);
                    }
                    else if (coordinatesPlayer[1] == 5)
                    {
                        CheckCoardinates(coordinatesPlayer, coordinatesRow5, coordinatesRow6, coordinatesRow4);
                    }
                    else if (coordinatesPlayer[1] == 6)
                    {
                        CheckCoardinates(coordinatesPlayer, coordinatesRow6, coordinatesRow7, coordinatesRow5);
                    }
                    else if (coordinatesPlayer[1] == 7)
                    {
                        CheckCoardinates(coordinatesPlayer, coordinatesRow7, coordinatesRow8, coordinatesRow6);
                    }
                    else if (coordinatesPlayer[1] == 8)
                    {
                        CheckCoardinates(coordinatesPlayer, coordinatesRow8, coordinatesRow9, coordinatesRow7);
                    }
                }
                Console.ReadLine();



            }
            int[] CheckCoardinates(int[] cordsPlayer, int[] cordsSameY, int[] cordsYPlus1, int[] cordsYMinus1)
            {


                return cordsPlayer;
            }
        }
    }
}