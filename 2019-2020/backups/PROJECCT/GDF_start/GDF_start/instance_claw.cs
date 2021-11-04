using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_claw : Instance
    {
        public instance_claw(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox();
            this.Model.SetBox();
            this.Model.SetTexture("noteblock.jpg");
        }

        protected override void Step()
        {
            if (GetKey(Key.W))
            {

                if (this._2D_DirectionFree(this.FacingDirection.Y, 0.9f, typeof(instance_floor)))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        this._2D_PositionAdd(this.FacingDirection.Y, 0.1f);

                    }
                }


            }

            if (GetKey(Key.A))
            {
                if (this._2D_DirectionFree(this.FacingDirection.Y - 90, 0.9f, typeof(instance_floor)))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        this._2D_PositionAdd(this.FacingDirection.Y + 90, -0.1f);

                    }
                }

            }
            if (GetKey(Key.S))
            {
                if (this._2D_DirectionFree(this.FacingDirection.Y + 180, 0.9f, typeof(instance_floor)))
                {
                    for (int i = 0; i < 10; i++)
                    {

                        this._2D_PositionAdd(this.FacingDirection.Y, -0.1f);
                    }
                }


            }
            

        }
        
    }
}
