using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_breakout
{
    public class room_main : Room
    {
        public room_main(string name) : base(name) { }

        protected override void Start()
        {
            this.InstanceCreate(0, 0.5f, 0, typeof(instance_bal));

            this.InstanceCreate(-10, 0.5f, 0, typeof(instance_muurVerticaal));
            this.InstanceCreate(10, 0.5f, 0, typeof(instance_muurVerticaal));
            this.InstanceCreate(0, 0.5f, 10.5f, typeof(instance_muurHorizontaal));
            this.InstanceCreate(0, 0.5f, -9f, typeof(instance_speler));

            this.Camera.SetCameraMode_Free();
            this.Camera.Position = new Vector3(0, 100, -100);
            this.Camera.Rotation_X = 45;
            this.Camera.FieldOfView = 7;

            Text2dCreate("gameover1", "Game Over", 16, 7, 40, true);
            Text2dCreate("gameover2", "Druk op enter om opnieuw te proberen", 16, 9.5f, 20, true);
            GetText2d("gameover1").SetColor(Color.FromHex("#1463ff"));
            GetText2d("gameover2").SetColor(Color.FromHex("#1463ff"));
            GetText2d("gameover1").Visible = false;
            GetText2d("gameover2").Visible = false;

        }

        protected override void Step()
        {
            if(Game.Input.GetKey(Urho.Key.Esc))
            {
                Game.Exit();
            }
        }
    }
}
