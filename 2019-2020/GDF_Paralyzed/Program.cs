using GDF;
using System;

namespace GDF_example_fps
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game.Settings.EnableLights = true;
            Game.Settings.EnableShadows = true;
            Game.Settings.AntiAliasing = Enums.Quality.Medium;
            Game.Settings.ShadowQuality = Enums.Quality.Medium;
            Game.Settings.MaterialQuality = Enums.Quality.Medium;
            Game.Settings.MaxFPS = 60;

            Game.Run(1280, 720, false, typeof(room_main));
        }
    }
}
