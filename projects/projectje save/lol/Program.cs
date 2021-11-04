using System;
using System.IO;
using System;
using System.IO;
using System.Collections;

namespace lol
{
    class Program
    {
        static void Main(string[] args)
        {
            /*foreach (string path in args)
            {
                if (File.Exists("J:/program_files/smartness/file.txt"))
                {

                }
                else if (Directory.Exists("J:/program_files/smartness"))
                {
                    File.Create(@"J:/program_files/smartness/file.txt");


                }
                else
                {
                    Directory.CreateDirectory("J:/program_files\\smartness");
                    File.Create(@"J:/program_files/smartness/file.txt");
                }*/
            string path = @"J:/program_files";
            FileAttributes attributes = File.GetAttributes(path);

            switch (attributes)
            {
                case FileAttributes.Directory:
                    if (Directory.Exists(path))
                        Console.WriteLine("This directory exists.");
                    else
                        Console.WriteLine("This directory does not exist.");
                    Console.ReadLine();
                    break;
                default:
                    if (File.Exists(path))
                        Console.WriteLine("This file exists.");
                    else
                        Console.WriteLine("This file does not exist.");
                    Console.ReadLine();
                    break;
            }




            if (File.Exists(@"T:/u_tay.txt"))
                {

                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {

                    }
                }
                /*for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("wie wil je testen?");
                    string antwoord = Console.ReadLine();

                    Random rnd = new Random(antwoord.GetHashCode());
                    Console.WriteLine(rnd.Next());



    
                }*/
                
            }


        }
    }

