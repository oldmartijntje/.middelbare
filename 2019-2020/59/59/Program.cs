using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            string kleuren = "rood_groen_blauw_geel_groen_oranje_paars_zwart_wit_poepbruin_grijs_beige_lichtblauw_grasgroen_antraciet";
            string namen = "renske;martijn;julian;mitch;boaz;martijn;ruben;thomas;lukas;gerben;luca;aron;twan;jack;victor";
            string vakken = "informatica/aardrijkskunde/geschiedenis/frans/duits/engels/nederlands/wiskunde/bewegings onderwijs/new/game design/mentoruur/pauze/tussenuur/opvangles";

            string[] gesplitsteKleuren = splitString(kleuren, "_", false);
            string[] gesplitsteNamen = splitString(namen, ";", true);
            string[] gesplitsteVakken = splitString(vakken, "/", true);

            for (int loop = 0; loop < 15; loop++)
            {
                Console.WriteLine("Het favoriete vak van " + gesplitsteNamen[loop] + " is " + gesplitsteVakken[loop] + ", en zijn/haar lievelingskleur is " + gesplitsteKleuren[loop] + ".");
            }
            
            Console.ReadLine();
        }
        /// <summary>
        /// split een string naar een string erray
        /// </summary>
        /// <param name="input">de string die je wilt splitten</param>
        /// <param name="splitCharacter">het teken dat weggehaald wordt</param>
        /// <param name="upcaseFirstLetter"></param>
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
    }
}
