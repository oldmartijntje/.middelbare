using System;
using GDF;
using Urho;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_player : Instance
    {
        public instance_player(uint id) : base(id) { }
        public float horizontalSpeed = 0.2f;
        public float mouseSensitivity = 4f;
        private float groundY = 0.5f;
        protected override void Start()
        {
            this.Collider.SetBox();
            this.Model.SetBox();
            this.Model.SetTexture("unknown.png", 1);
            //this.FacingDirectionSpeed.Y = 1;
            //draaien
        }

        protected override void Step()
        {
            //beweging
            if (GetKey(Key.W) && this._2D_DirectionFree(this.FacingDirection.Y, this.horizontalSpeed, typeof(Instance)))
                this._2D_PositionAdd(this.FacingDirection.Y, this.horizontalSpeed);
            if (GetKey(Key.S) && this._2D_DirectionFree(this.FacingDirection.Y + 180, this.horizontalSpeed, typeof(Instance)))
                this._2D_PositionAdd(this.FacingDirection.Y + 180, this.horizontalSpeed);
            if (GetKey(Key.A) && this._2D_DirectionFree(this.FacingDirection.Y - 90, this.horizontalSpeed, typeof(Instance)))
                this._2D_PositionAdd(this.FacingDirection.Y - 90, this.horizontalSpeed);
            if (GetKey(Key.D) && this._2D_DirectionFree(this.FacingDirection.Y + 90, this.horizontalSpeed, typeof(Instance)))
                this._2D_PositionAdd(this.FacingDirection.Y + 90, this.horizontalSpeed);
            if (GetKey(Key.Space) && Y == this.groundY)
            {
                Speed.Y = 0.3f;
            }

            //camera
            this.FacingDirection.Y += Game.Input.MouseXchange * this.mouseSensitivity;
            this.FacingDirection.X += Game.Input.MouseYchange * this.mouseSensitivity;

            //camera limiet
            if (this.FacingDirection.X > 80 && this.FacingDirection.X < 180)
                this.FacingDirection.X = 80;
            if (this.FacingDirection.X < 270 && this.FacingDirection.X > 180)
                this.FacingDirection.X = 270;

            //gravity
            this.groundY = 0.5f;
            foreach (Instance block in DetectCollisions(typeof(instance_block)))
            {
                if (block.Y < Y)
                {
                    Y = Position_previous.Y;
                    this.groundY = Y;
                }
                Speed.Y = 0;
            }
            if (Y > this.groundY)
            {
                Speed.Y -= 0.015f;
            }
            if (Y < this.groundY)
            {
                Speed.Y = 0;
                Y = this.groundY;
            }

            //mhm
            foreach (Instance block in Game.CurrentRoom.InstancesAtPlace(new Vector3(X, Y - 0.5f, Z), 0.5f, typeof(instance_block)))
            {
                if (_2D_DistanceToInstance(block) > 0.5f)
                {
                    _2D_PositionAdd(Methods._2D_DirectionBetweenPoints(block.Position, Position), _2D_DistanceToInstance(block) * 0.05f);
                }
            }
        }
    }
}
