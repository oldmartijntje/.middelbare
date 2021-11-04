using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDF_example_fps
{
    public class room_main : Room
    {
        public room_main(string name) : base(name) { }

        protected override void Start()
        {
            this.Size = Vector3.One * 200;
            
            this.Light.Ambient = 0.6f;
            this.Light.Brightness = 1.2f;

            this.RemoveGrid();

            this.InstanceCreate(Vector3.Zero, typeof(instance_sky));

            //maak de het spelervoorwerp en stel de camera in dat hij deze volgt
            Instance fps = this.InstanceCreate(100, new Vector3(30, 0, 0), typeof(instance_player));
            this.Camera.SetCameraMode_FirstPerson(fps, 0);

            //maak ballen verspreid over het speelveld
            for (int x = -4; x<4; x++)
            {
                for(int z = -4; z<4; z++)
                {
                    this.InstanceCreate(new Vector3(x * 20, 5f, z * 20), typeof(instance_ball));
                }
            }

            //maak de 2d afbeeldingen aan: het mikpunt en het wapen
            this.Image2dCreate("crossair", "crossair.png", 15.95f, 16f / Game.AspectRatio - 0.05f, 0.1f, 0.1f);
            this.Image2dCreate("weapon", "weapon.png", 16 * 0.85f, 16 / Game.AspectRatio, 24f, 16f);
       
            //maak de vloer
            this.InstanceCreate(200, Vector3.Zero, typeof(instance_floor));

            this.Text2dCreate("gameover", "druk op enter om opnieuw te proberen", 16, 8, 20);
            this.GetText2d("gameover").SetHorizontalAlignmentCenter();
            this.GetText2d("gameover").Visible = false;
        }


        protected override void Step()
        {
            if (Game.Input.GetKey(Urho.Key.Esc))
            {
                Environment.Exit(0);
            }

            Game.Title = "GDF - Shooter example";
        }
    }
}
