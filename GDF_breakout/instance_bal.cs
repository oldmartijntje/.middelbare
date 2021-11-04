using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_breakout
{
    public class instance_bal : Instance
    {
        public instance_bal(uint id) : base(id) { }
        public int extraSpeed = 0;
        public bool pause = false;
        
        protected override void Start()
        {
            this.Model.SetSphere();
            this.Model.Size = Vector3.One * 0.3f;
            this.Model.SetColor(Color.FromHex("#1463ff"));
            this.Collider.SetSphere(0.3f);
            
        }

        protected override void Step()
        {


                if (GetKey(Key.Ctrl) && GetKey(Key.Shift))
            {
                Position = new Vector3(0, 0.5f, 0);
                this.Speed.Z = -this.Speed.Z;
            }

            if (FrameCount > 60 && Speed.Z == 0)
            {
                
                    _2D_MotionSet(135 + Randoms.Next(0, 90), 0.1f);
                
            }

            if (Position.Z < -12)
            {
                Game.CurrentRoom.GetText2d("gameover1").Visible = true;
                Game.CurrentRoom.GetText2d("gameover2").Visible = true;

                if (GetKey(Key.Return))
                {
                    Game.CurrentRoom.Restart();
                }
            }

            foreach (instance_speler speler in DetectCollisions(typeof(instance_speler)))
            {
                Console.WriteLine("test");
                this.Speed.Z = -this.Speed.Z;

                float xdiff = (this.X - speler.X) / (speler.Collider.Size.X * 0.5f);

                _2D_Direction += xdiff * 45;

                if (_2D_Direction < 300 && _2D_Direction >= 180)
                {
                    _2D_Direction = 300;
                }
                if (_2D_Direction > 60 && _2D_Direction < 180)
                {
                    _2D_Direction = 60;
                }
            }
            foreach (instance_muurHorizontaal speler in DetectCollisions(typeof(instance_muurHorizontaal)))
            {
                this.extraSpeed += 1;
                Console.WriteLine(this.Speed.X);
                Console.WriteLine(this.Speed.Z);
                Console.WriteLine(this.extraSpeed);
                this.Speed.Z = -this.Speed.Z;
                if (this.extraSpeed > 5)
                {
                    Console.WriteLine("YEET");
                    if (this.Speed.X > 0)
                    {
                        this.Speed.X += 0.01f;
                    }
                    else
                    {
                        this.Speed.X -= 0.01f;
                    }
                    if (this.Speed.Z > 0)
                    {
                        this.Speed.Z += 0.01f;
                    }
                    else
                    {
                        this.Speed.Z -= 0.01f;
                    }
                    this.extraSpeed = 0;
                }
            }
            foreach (instance_muurVerticaal speler in DetectCollisions(typeof(instance_muurVerticaal)))
            {

                this.Speed.X = -this.Speed.X;
                this.extraSpeed += 1;
                Console.WriteLine(this.Speed.X);
                Console.WriteLine(this.Speed.Z);
                Console.WriteLine(this.extraSpeed);
                if (this.extraSpeed > 5)
                {

                    if (this.Speed.X > 0)
                    {
                        this.Speed.X += 0.01f;
                    }
                    else
                    {
                        this.Speed.X -= 0.01f;
                    }
                    if (this.Speed.Z > 0)
                    {
                        this.Speed.Z += 0.01f;
                    }
                    else
                    {
                        this.Speed.Z -= 0.01f;
                    }
                    this.extraSpeed = 0;
            if (GetKey(Key.Space))
            {
                if (this.pause = false)
                {
                    this.pause = true;
                }
                else
                {
                    this.pause = false;
                }
            }
            while (this.pause = true)
            {
                if (GetKey(Key.Space))
                {
                    this.pause = false;
                }
                Position = new Vector3(0, 0.5f, 0);
                this.Speed.Z = this.Speed.Z;
            }
                }
            }


        }
    }
}
