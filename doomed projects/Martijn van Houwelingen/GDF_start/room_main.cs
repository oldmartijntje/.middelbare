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
        public room_main(string name) : base(name) { }
        

        protected override void Start()
        {
            Instance player = this.InstanceCreate(1, 6.5f, 1, typeof(instance_player));
            this.Camera.SetCameraMode_FirstPerson(player, 0.40f);

            this.RemoveGrid();
            //block
            for (int ict = 0; ict < 10; ict++)
            {
                for (int een = 0; een < 3; een++)
                {
                    
                    for (int q = 0; q < 20; q++)
                    {
                        this.InstanceCreate(ict, 0.5f, een, typeof(instance_block));
                        this.InstanceCreate(ict + 10, 1.5f, een, typeof(instance_block));
                        
                        this.InstanceCreate(ict +27, 0.5f, een, typeof(instance_block));
                        this.InstanceCreate(ict + 37, 1.5f, een, typeof(instance_block));
                        
                    }
                }
               /* this.InstanceCreate(50, 1.5f, 0, typeof(instance_block));
                this.InstanceCreate(50, 1.5f, 1, typeof(instance_block));
                this.InstanceCreate(50, 1.5f, 2, typeof(instance_block));
                this.InstanceCreate(53, 1.5f, 0, typeof(instance_block));
                this.InstanceCreate(53, 1.5f, 1, typeof(instance_block));
                this.InstanceCreate(53, 1.5f, 2, typeof(instance_block));
                this.InstanceCreate(56, 2.5f, 0, typeof(instance_block));
                this.InstanceCreate(56, 2.5f, 1, typeof(instance_block));
                this.InstanceCreate(56, 2.5f, 2, typeof(instance_block));
                this.InstanceCreate(60, 4.5f, 0, typeof(instance_block));
                this.InstanceCreate(60, 4.5f, 1, typeof(instance_block));
                this.InstanceCreate(60, 4.5f, 2, typeof(instance_block));
                this.InstanceCreate(70, -2.5f, 0, typeof(instance_block));
                this.InstanceCreate(70, -2.5f, 1, typeof(instance_block));
                this.InstanceCreate(70, -2.5f, 2, typeof(instance_block));
                this.InstanceCreate(71, -2.5f, 0, typeof(instance_block));
                this.InstanceCreate(71, -2.5f, 1, typeof(instance_block));
                this.InstanceCreate(71, -2.5f, 2, typeof(instance_block));
                this.InstanceCreate(72, -2.5f, 0, typeof(instance_block));
                this.InstanceCreate(72, -2.5f, 1, typeof(instance_block));
                this.InstanceCreate(72, -2.5f, 2, typeof(instance_block));
                this.InstanceCreate(73, 0.5f, 0, typeof(instance_block));
                this.InstanceCreate(73, 0.5f, 1, typeof(instance_block));
                this.InstanceCreate(73, 0.5f, 2, typeof(instance_block));
                this.InstanceCreate(74, 3.5f, 0, typeof(instance_block));
                this.InstanceCreate(74, 3.5f, 1, typeof(instance_block));
                this.InstanceCreate(74, 3.5f, 2, typeof(instance_block));
                this.InstanceCreate(80, 3.5f, 0, typeof(instance_block));
                this.InstanceCreate(80, 3.5f, 1, typeof(instance_block));
                this.InstanceCreate(80, 3.5f, 2, typeof(instance_block));
                this.InstanceCreate(81, 3.5f, 0, typeof(instance_block));
                this.InstanceCreate(81, 3.5f, 1, typeof(instance_block));
                this.InstanceCreate(81, 3.5f, 2, typeof(instance_block));
                this.InstanceCreate(82, 3.5f, 0, typeof(instance_block));
                this.InstanceCreate(82, 3.5f, 1, typeof(instance_block));
                this.InstanceCreate(82, 3.5f, 2, typeof(instance_block));
                this.InstanceCreate(83, 3.5f, 0, typeof(instance_block));
                this.InstanceCreate(83, 3.5f, 1, typeof(instance_block));
                this.InstanceCreate(83, 3.5f, 2, typeof(instance_block));
                for (int i = 0; i < 7; i++)
                {
                    this.InstanceCreate(84, i + 3.5f, 0, typeof(instance_block));
                    this.InstanceCreate(84, i + 3.5f, 1, typeof(instance_block));
                    this.InstanceCreate(84, i + 3.5f, 2, typeof(instance_block));
                    this.InstanceCreate(88, i + 10.5f, -0.5f, typeof(instance_block));
                    this.InstanceCreate(88, i + 9.5f, 1, typeof(instance_block));
                    this.InstanceCreate(88, i + 10.5f, 2.5f, typeof(instance_block));
                    this.InstanceCreate(92, i + 10.5f, 0, typeof(instance_block));
                    this.InstanceCreate(92, i + 10.5f, 1, typeof(instance_block));
                    this.InstanceCreate(92, i + 10.5f, 2, typeof(instance_block));
                    this.InstanceCreate(92, i + 15.5f, -0.5f, typeof(instance_block));
                    this.InstanceCreate(92, i + 20f, 1, typeof(instance_block));
                    this.InstanceCreate(92, i + 15.5f, 2.5f, typeof(instance_block));
                    this.InstanceCreate(92, i + 22.5f, -0.5f, typeof(instance_block));
                    this.InstanceCreate(92, i + 27f, 1, typeof(instance_block));
                    this.InstanceCreate(92, i + 22.5f, 2.5f, typeof(instance_block));
                }
                for (int i = 0; i < 6; i++)
                {
                this.InstanceCreate(i + 85, 3.5f, 0, typeof(instance_block));
                this.InstanceCreate(i + 85, 3.5f, 1, typeof(instance_block));
                this.InstanceCreate(i + 85, 3.5f, 2, typeof(instance_block));
                this.InstanceCreate(i + 93, 16.5f, 0, typeof(instance_block));
                this.InstanceCreate(i + 93, 16.5f, 1, typeof(instance_block));
                this.InstanceCreate(i + 93, 16.5f, 2, typeof(instance_block));
                    this.InstanceCreate(i + -107, 116.5f, 0, typeof(instance_block));
                    this.InstanceCreate(i + -107, 116.5f, 1, typeof(instance_block));
                    this.InstanceCreate(i + -107, 116.5f, 2, typeof(instance_block));

                }
                */
                for (int oop = 0; oop < 3; oop++)
                {
                    for (int a = 0; a < 3; a++)
                    {
                        this.InstanceCreate(28 + a, 6.5f, 0 + oop, typeof(instance_block));
                    }
                } 

                //checkpoints
                this.InstanceCreate(29, 1.5f, 1, typeof(instance_cp));
                this.InstanceCreate(71, -1.5f, 1, typeof(instance_cp));
                this.InstanceCreate(81, 4.5f, 1, typeof(instance_cp));

                //teleporter
                this.InstanceCreate(97, 17.5f, 1, typeof(instance_teleporter));

                //powerups
                this.InstanceCreate(29, 7.5f, 1, typeof(instance_cape));
                this.InstanceCreate(31, 1.5f, 1, typeof(instance_moongravity));
                this.InstanceCreate(82, 4.5f, 1, typeof(instance_moongravity));

                //arrow
                this.InstanceCreate(5, 1.5f, 15, typeof(instance_block));
                this.InstanceCreate(4, 1.5f, 15, typeof(instance_block));
                this.InstanceCreate(4, 0.5f, 15, typeof(instance_block));
                this.InstanceCreate(4, 2.5f, 15, typeof(instance_block));
                this.InstanceCreate(3, 3.5f, 15, typeof(instance_block));
                this.InstanceCreate(3, -0.5f, 15, typeof(instance_block));
                this.InstanceCreate(3, 1.5f, 15, typeof(instance_block));
                this.InstanceCreate(2, 1.5f, 15, typeof(instance_block));
                this.InstanceCreate(1, 1.5f, 15, typeof(instance_block));
                this.InstanceCreate(0, 1.5f, 15, typeof(instance_block));
                this.InstanceCreate(-1, 1.5f, 15, typeof(instance_block));
                this.InstanceCreate(-2, 1.5f, 15, typeof(instance_block));

                
                //arrow 2
                this.InstanceCreate(5, 1.5f, -15, typeof(instance_block));
                this.InstanceCreate(4, 1.5f, -15, typeof(instance_block));
                this.InstanceCreate(4, 0.5f, -15, typeof(instance_block));
                this.InstanceCreate(4, 2.5f, -15, typeof(instance_block));
                this.InstanceCreate(3, 3.5f, -15, typeof(instance_block));
                this.InstanceCreate(3, -0.5f, -15, typeof(instance_block));
                this.InstanceCreate(3, 1.5f, -15, typeof(instance_block));
                this.InstanceCreate(2, 1.5f, -15, typeof(instance_block));
                this.InstanceCreate(1, 1.5f, -15, typeof(instance_block));
                this.InstanceCreate(0, 1.5f, -15, typeof(instance_block));
                this.InstanceCreate(-1, 1.5f, -15, typeof(instance_block));
                this.InstanceCreate(-2, 1.5f, -15, typeof(instance_block));
                //parkour

               
                

                

                //lives

                


                
            }
            
        }

        protected override void Step()
        {
            if (Game.Input.GetKey(Key.Backspace) && (Game.Input.GetKey(Key.LeftShift)))
            {
                Game.RoomRestart(this.Name);
            }
            if (Game.Input.GetKey(Urho.Key.Esc) && Game.Input.GetKey(Urho.Key.LeftShift))
            {
                Game.Exit();
            }
            
        }
       
    }
}
