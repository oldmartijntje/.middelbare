using GDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Game.Settings.EnableLights = true;
            Game.Settings.EnableShadows = true;
            Game.Settings.AntiAliasing = Enums.Quality.Medium;
            Game.Settings.ShadowQuality = Enums.Quality.Medium;
            Game.Settings.MaterialQuality = Enums.Quality.Medium;
            Game.Settings.MaxFPS = 60;
            Game.Settings.FullScreen = false;
            Game.Settings.ResolutionWidth = 1280;
            Game.Settings.ResolutionHeight = 720;

            Game.Run(typeof(room_main));
        }
    }
}
