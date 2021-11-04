using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Give your file a name");
            string nameFile = Console.ReadLine();
            MakeFile(nameFile);
            Console.WriteLine("type your code here:");
            string String2 = Console.ReadLine();
            String2 = String2 + "a ";


            string[] stringErray1 = splitString(String2, "a", false);
            
            Code(stringErray1, nameFile);
            

            /*for (int i = 0; i < stringErray1.Length; i++)
            {
                Console.WriteLine(stringErray1[i]); 
            }*/
            Console.WriteLine("completely made your code");
            Console.WriteLine("go check it out in the Bin map, and then in the Debug map");
            Console.WriteLine("its named: " + nameFile);
            Console.ReadLine();
        }
        /// <summary>
        /// removes / from the string and puts everything in a erray
        /// </summary>
        /// <param name="input">the string you want to split</param>
        /// <param name="splitCharacter">what the character is that its going to remove</param>
        /// <param name="upcaseFirstLetter">start with a capital letter</param>
        /// <returns></returns>
        private static string[] splitString(string input, string splitCharacter, bool upcaseFirstLetter)
        {
            string[] result = input.Split(new string[] { splitCharacter }, StringSplitOptions.None);

            if (upcaseFirstLetter)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = result[i].Substring(0, 1).ToUpper() + result[i].Substring(1);
                }
            }

            return result;
        }
        /// <summary>
        /// making a file
        /// </summary>
        /// <param name="fileName">the name you want to give it</param>
        static void MakeFile(string fileName)
        {

            string fileName2 = fileName;
            string fileNameFull = @"C:\\Temp\\" + fileName2 + ".txt";
            int whileloop1 = 0;
            int counting = 1;
            try
            {
                while (whileloop1 != 1)
                {
                    fileNameFull = @"C:\\Temp\\" + fileName2 + ".txt";
                    // Check if file already exists. If yes, delete it. 
                    if (File.Exists(fileNameFull))
                    {
                        fileName2 = fileName + "(" + counting + ")";
                        counting = counting + 1;
                    }
                    else
                    {
                        whileloop1 = 1;
                    }
                }


                // Create a new file 
                using (StreamWriter sw = File.CreateText(fileName2))
                {
                    sw.WriteLine("Installed Date: {0}", DateTime.Now.ToString());
                    sw.WriteLine("Thermo Licensing System file");

                    DateTime newDate = DateTime.Now.AddDays(31);
                    sw.WriteLine("License Expires After" + newDate);

                    // sw.WriteLine("Add ");
                    // sw.WriteLine("Done! ");
                }

                // Write file contents on console. 
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        static void Code(string[] code, string filename)
        {
            using (StreamWriter writetext = new StreamWriter(filename + ".txt"))
            {
                for (int i = 0; i < code.Length; i++)
                {
                    if (i == 0)
                    {
                        writetext.Write(code[i] + "а");
                    }
                    else
                    {
                        writetext.Write("а" + code[i]);
                    }
                    
                }
                
                

            }
        }
    }
}
