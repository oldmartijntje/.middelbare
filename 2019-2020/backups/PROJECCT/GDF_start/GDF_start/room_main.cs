using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GDF_start
{
    public class room_main : Room
    {
        public room_main(string name) : base(name) { }

        protected override void Start()
        {
            this.Camera.SetCameraMode_Free();
            this.Camera.X = 0;
            this.Camera.Y = 3.5f;
            this.Camera.Z = -15;

//          de magnet
            this.InstanceCreate(-7, 9.4f, 0, typeof(instance_claw));

            //de border
            
            for (int i = 0; i < 17; i++)
            {
                this.InstanceCreate(-8 + i, 0.5f, 0, typeof(instance_floor));
                this.InstanceCreate(-8 + i, 10.5f, 0, typeof(instance_floor));
                this.InstanceCreate(-8, i + 0.5f, 0, typeof(instance_floor));
                this.InstanceCreate(8,i + 0.5f, 0, typeof(instance_floor));
            }
            ClawGoRight();
            ClawGoLeft();
            ClawGrab();
            
        }

        protected override void Step()
        {
            if(Game.Input.GetKey(Urho.Key.Esc))
            {
                Game.Exit();
            }
        }
        static void ClawGoRight()
        {
            instance_claw claw = (instance_claw)Game.CurrentRoom.GetInstanceByType(typeof(instance_claw));


            if (claw._2D_DirectionFree(claw.FacingDirection.Y + 90, 0.9f, typeof(instance_floor)))
            {
                for (int i = 0; i < 100; i++)
                {
                    claw.Position.X += 0.01f;

                }
            }



        }
        static void ClawGoLeft()
        {
            instance_claw claw = (instance_claw)Game.CurrentRoom.GetInstanceByType(typeof(instance_claw));


            if (claw._2D_DirectionFree(claw.FacingDirection.Y - 90, 0.9f, typeof(instance_floor)))
            {
                for (int i = 0; i < 100; i++)
                {
                    claw.Position.X -= 0.01f;
                    Thread.Sleep(20);
                }
            }



        }
        static void ClawGrab()
        {
            instance_claw claw = (instance_claw)Game.CurrentRoom.GetInstanceByType(typeof(instance_claw));


            
                while (claw._2D_DirectionFree(claw.FacingDirection.X - 90, -0.9f, typeof(instance_floor)))
                {
                for (int i = 0; i < 100d; i++)
                {
                    claw.Position.Y -= 0.01f;
                    
                }
            }
                
            



        }

    }
}
