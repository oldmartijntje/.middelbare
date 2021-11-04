using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] VoorNamen = new string[4]
            {
                "Boaz ","Skeppy ","string[] BijNaam = ","Grian "
            };
            string[] TussenVoegsel = new string[4]
            {
                "de ","Plays ","new string[3] ","The "
            };
            string[] AchterNamen = new string[4]
            {
                "Haan","Minecraft","{Thomas,YEET,Koman}","Chicken"
            };
            Console.WriteLine("Als ik een schildpad als huisdier had, zou die heten: " + VoorNamen[0] + TussenVoegsel[0] + AchterNamen[0]);
            Console.WriteLine("Als ik ooit een dansje zou doen zou ik hem noemen: " + VoorNamen[1] + TussenVoegsel[1] + AchterNamen[1]);            
            Console.WriteLine("The beste Kip in het universum is: " + VoorNamen[3] + TussenVoegsel[3] + AchterNamen[3]);
            Console.WriteLine("Kan opdracht niet uitvoeren: " + VoorNamen[2] + TussenVoegsel[2] + AchterNamen[2]);
            Console.ReadLine();
            
        }
    }
}
