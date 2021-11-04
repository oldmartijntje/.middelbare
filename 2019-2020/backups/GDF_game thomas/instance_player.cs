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
        private bool checkpoint1 = true;
        private bool checkpoint2 = false;
        private bool checkpoint3 = false;
        float gravity = 0.015f;
        protected override void Start()
        {
            this.Friction = 0.005f;
            this.Gravity = gravity;
            this.Collider.SetBox();
            this.Model.Delete();
        }

        protected override void Step()
        {


            //Controlls
            if (GetKey(Key.Space))
            {
                
                    this.Begin = true;
                
            }
            if (this.Begin == true)
            {
                if (Game.CurrentRoom.Lives > 0)
                {


                    if (GetKey(Key.W) && this._2D_DirectionFree(this.FacingDirection.Y, 0.5f, typeof(instance_block)))
                    {
                        this._2D_PositionAdd(this.FacingDirection.Y, 0.105f);
                    }
                    if (GetKey(Key.A) && this._2D_DirectionFree(this.FacingDirection.Y - 90, 0.5f, typeof(instance_block)))
                    {
                        this._2D_PositionAdd(this.FacingDirection.Y + 90, -0.105f);
                    }
                    if (GetKey(Key.S) && this._2D_DirectionFree(this.FacingDirection.Y + 180, 0.5f, typeof(instance_block)))
                    {
                        this._2D_PositionAdd(this.FacingDirection.Y, -0.105f);
                    }
                    if (GetKey(Key.D) && this._2D_DirectionFree(this.FacingDirection.Y + 90, 0.5f, typeof(instance_block)))
                    {
                        this._2D_PositionAdd(this.FacingDirection.Y + 90, 0.105f);
                    }
                    if (GetKey(Key.Space))
                    {
                        if (this.JumpReady == true)
                        {
                            if (this.Jump == true && !this.PositionFree(new Vector3(0, -1, 0), typeof(instance_block)))
                            {
                                this.Speed.Y += 0.3f;
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
                    if (!GetKey(Key.Space))
                    {
                        this.JumpReady = true;
                    }
                    if (GetKey(Key.R))
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
            if (!this.PositionFree(new Vector3(0, 0.0000000000000001f, 0), typeof(instance_block)))
            {
                if(this.Speed.Y >= 0)
                {
                    this.Speed.Y = 0;
                }
                        
            }
            if (!this.PositionFree(new Vector3(0, -0.75f, 0), typeof(instance_block))) 
            {
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
           

            if(this.NoCollision == true)
            {
                this.Gravity = gravity;
            }

            //Removes live if falls
            if (this.Position.Y <= -10)
            {
                Game.CurrentRoom.Lives--;
                this.Position.Y = 2.5f;
                this.Position.X = 5;
                this.Position.Z = 5;
            }
        }
    }
}
