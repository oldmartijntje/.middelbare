using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace file_maker_test
{
    class Program
    {
        static void Main()
        {
            string saveName;
            string fileName;
            string openFile;
            while (true)
            {
                Console.WriteLine("What do you want to do?");

                string command = Console.ReadLine();
                if (command == "save")
                {
                    Console.WriteLine("Waht do you want to call the save?");
                    saveName = Console.ReadLine();
                    Console.WriteLine("What kind of file?(Type the filename)");
                    fileName = Console.ReadLine();
                    File.Create(saveName + fileName);
                    File.Encrypt(saveName + fileName);
                }
                if (command == "edit")
                {
                    Console.WriteLine("Wich file do you want to edit?");
                    openFile = Console.ReadLine();
                    try
                    {
                        StreamReader sr = null;

                        
                    }
                    catch(FileNotFoundException)
                    {
                        Console.WriteLine("That file does not exist");
                    }
                }
                Console.Read();
            }
        }
    }
}
