using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class room_main : Room
    {
        public room_main() : base() { }

        protected override void Start()
        {
            LoadOwnPlayer();
            LoadMap();
        }
        protected void LoadOwnPlayer()
        {
            Instance player1 = this.InstanceCreate(100, new Vector3(0, 0.5f, 0), typeof(instance_player));
            this.Camera.SetCameraMode_FirstPerson(player1, 1);
            player1.Model.Delete();
            Image2dCreate("crossair", "crossair1.png", UIWidth / 2, UIHeight / 2, 1f, 1f);
        }
        protected void LoadMap()
        {
            this.InstanceCreate(1, 0.5f, 0, typeof(instance_block));
            this.InstanceCreate(1, 1.5f, 0, typeof(instance_block));
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
