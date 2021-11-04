using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{

    public class instance_player : Instance
    {
        public instance_player(uint id) : base(id) { }
        private bool Jump = false;
        private bool JumpReady = false;
        private bool NoCollision = true;
        private bool DoubleJump = false;
        private bool RPress = false;
        private bool Begin = false;
        public bool Respawn = false;
        float gravity = 0.015f;
        public float XXX = 1;
        public float YYY = 5.5f;
        public float ZZZ = 1;
        public int powerup = 0;
        public bool Diveroll = true;
        protected override void Start()
        {
            this.Friction = 0.005f;
            this.Gravity = gravity;
            this.Collider.SetBox();
            this.Model.Delete();
            
            this.FacingDirection.Y = 90;
            
            
        }

        protected override void Step()
        {
            

            if (Game.Input.GetKey(Key.Backspace))
            {
                this.Position.Y = YYY;
                this.Position.X = XXX;
                this.Position.Z = ZZZ;
                this.FacingDirection.Y = 90;
                
               
            }
            
            if (GetKey(Key.W) )
            {
                
                if (this._2D_DirectionFree(this.FacingDirection.Y, 0.2f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y, 0.2f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y, 0.1f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y, 0.1f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y, 0.05f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y, 0.05f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y, 0.01f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y, 0.01f);
                }

            }
            
            if (GetKey(Key.A))
            {
                if (this._2D_DirectionFree(this.FacingDirection.Y - 90, 0.2f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y + 90, -0.2f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y - 90, 0.1f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y + 90, -0.1f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y - 90, 0.05f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y + 90, -0.05f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y - 90, 0.01f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y + 90, -0.01f);
                }
            }
            if (GetKey(Key.S))
            {
                if (this._2D_DirectionFree(this.FacingDirection.Y + 180, 0.2f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y, -0.2f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y + 180, 0.1f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y, -0.1f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y + 180, 0.05f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y, -0.05f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y + 180, 0.01f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y, -0.01f);
                }

            }
            if (GetKey(Key.D) )
            {
                if (this._2D_DirectionFree(this.FacingDirection.Y + 90, 0.2f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y + 90, 0.2f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y + 90, 0.1f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y + 90, 0.1f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y + 90, 0.05f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y + 90, 0.05f);
                }
                else if (this._2D_DirectionFree(this.FacingDirection.Y + 90, 0.01f, typeof(instance_block)))
                {
                    this._2D_PositionAdd(this.FacingDirection.Y + 90, 0.01f);
                }

            }
            if (GetKey(Key.Space) )
            {
                if (this.JumpReady == true)
                {
                    if (this.Jump == true && !this.PositionFree(new Vector3(0, -1, 0), typeof(instance_block)))
                    {
                        this.Speed.Y += 0.35f;
                        if (this.DoubleJump == false)
                        {
                            this.Jump = false;
                            this.JumpReady = false;
                            
                        }
                        else
                        {
                            if (this.JumpReady == true)
                            {
                                if (this.Jump == true)
                                {
                                    this.Speed.Y += 0.3f;
                                    this.Jump = false;
                                   
                                    this.JumpReady = false;
                                    
                                }
                            }

                        }
                    }
                } 
            }
            //project longjump
            /*
            if (GetKey(Key.Space) && GetKey(Key.Q))
            {
                if (this.JumpReady == true)
                {
                    if (this.Jump == true && !this.PositionFree(new Vector3(0, -1, 0), typeof(instance_block)))
                    {
                        this.Speed.Y += 0.20f;
                        if (this.DoubleJump == false)
                        {
                            this.Jump = false;
                            this.JumpReady = false;
                            for (int i = 0; i < 200; i++)
                            {
                                if (this._2D_DirectionFree(this.FacingDirection.Y, i / 1000 + 0.02f, typeof(instance_block)))
                                {
                                    this._2D_PositionAdd(this.FacingDirection.Y, i / 1000 + 0.02f);
                                }
                                
                            }
                        }
                        else
                        {
                            if (this.JumpReady == true)
                            {
                                if (this.Jump == true)
                                {
                                    this.Speed.Y += 0.3f;
                                    this.Jump = false;

                                    this.JumpReady = false;

                                }
                            }

                        }
                    }
                }
            }
            */
           /* else if (GetKey(Key.R))
            {
                
                if (this.Speed.Y != 0)
                {
                    if (this.Diveroll = true || this.Jump == true)
                    {
                        this.Diveroll = false;
                     

                    this.Speed.Y = -0.035f;


                    if (this._2D_DirectionFree(this.FacingDirection.Y, 0.4f, typeof(instance_block)))
                    {
                        this._2D_PositionAdd(this.FacingDirection.Y, 0.4f);
                    
                    }
                    } 
                }  
                }
                */
                if (GetKey(Key.LeftShift) && this.powerup != 0)
                {
                    if (this.powerup == 1)
                    {

                        if (this.Speed.Y != 0)
                        {

                            this.Speed.Y += 0.009f;
                        }
                    }
                    else if (this.powerup == 2)
                    {
                    
                        if (this.Speed.Y < 0)
                        {
                            this.Speed.Y = -0.015f;
                        if (GetKey(Key.W))
                        {

                        }
                        else
                        {
                            if (this._2D_DirectionFree(this.FacingDirection.Y, 0.2f, typeof(instance_block)))
                            {
                                this._2D_PositionAdd(this.FacingDirection.Y, 0.2f);
                            }
                            else if (this._2D_DirectionFree(this.FacingDirection.Y, 0.1f, typeof(instance_block)))
                            {
                                this._2D_PositionAdd(this.FacingDirection.Y, 0.1f);
                            }
                            else if (this._2D_DirectionFree(this.FacingDirection.Y, 0.05f, typeof(instance_block)))
                            {
                                this._2D_PositionAdd(this.FacingDirection.Y, 0.05f);
                            }
                            else if (this._2D_DirectionFree(this.FacingDirection.Y, 0.01f, typeof(instance_block)))
                            {
                                this._2D_PositionAdd(this.FacingDirection.Y, 0.01f);
                            }
                        }
                    }
                    
                    }

                }
            
            
            if (!GetKey(Key.Space))
            {
                this.JumpReady = true;
            }
            if (GetKey(Key.Backspace))
            {
                if (this.Speed.Y == 0)
                {
                    if (this.RPress == false)
                    {
                        this.Position.Y = 2.5f;
                        this.Position.X = 5;
                        this.Position.Z = 5;
                        this.RPress = true;
                    }
                }
            }
            else
            {
                if (this.RPress == true)
                {
                    this.RPress = false;
                }
            }
           



            //MouseCam

            this.FacingDirection.Y += Game.Input.MouseXchange * 1.2f;
            this.FacingDirection.X += Game.Input.MouseYchange * 1.2f;
            if (this.FacingDirection.X > 80 && this.FacingDirection.X < 180)
                this.FacingDirection.X = 80;
            if (this.FacingDirection.X < 270 && this.FacingDirection.X > 180)
                this.FacingDirection.X = 270;

            //Collision
            if (!this.PositionFree(new Vector3(0, 0.4f, 0), typeof(instance_block)))
            {
                if (this.Speed.Y >= 0)
                {
                    this.Speed.Y = 0;
                    
                }

            }
            if (!this.PositionFree(new Vector3(0, -0.75f, 0), typeof(instance_block)))
            {
                this.Diveroll = true;
                this.NoCollision = false;
                this.Jump = true;
                this.Gravity = 0;
                if (this.Speed.Y <= 0)
                {
                    this.Speed.Y = 0;
                }
                
            }
            else
            {
                this.NoCollision = true;
            }


            if (this.NoCollision == true)
            {
                this.Gravity = gravity;
            }

            if (this.DetectCollision(typeof(instance_cp)))
            {
                XXX = this.Position.X;
                YYY = this.Position.Y;
                ZZZ = this.Position.Z;
                
            }
            if (this.DetectCollision(typeof(instance_teleporter)))
            {
                XXX = this.Position.X - 200;
                YYY = this.Position.Y + 100;
                ZZZ = this.Position.Z;
                this.Position.Y = YYY + 2;
                this.Position.X = XXX;
                this.Position.Z = ZZZ;
                this.FacingDirection.Y = 90;
                this.powerup = 0;
                this.Speed.Y = 0;

            }
            if (this.DetectCollision(typeof(instance_moongravity)))
            {
                this.powerup = 1;
            }
            if (this.DetectCollision(typeof(instance_cape)))
            {
                this.powerup = 2;
            }
            // if falls
            if (this.Position.Y <= YYY -20)
            {
                
                this.Position.Y = YYY + 2;
                this.Position.X = XXX;
                this.Position.Z = ZZZ;
                this.FacingDirection.Y = 90;
                this.powerup = 0;

            }
        }
    }
}
