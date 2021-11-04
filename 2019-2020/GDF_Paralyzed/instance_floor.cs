using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_example_fps
{
    public class instance_floor : Instance
    {
        public instance_floor(uint id) : base(id)
        {
        }

        protected override void Start()
        {
            this.Collider.SetBox(new Vector3(Game.CurrentRoom.Size.X, 1, Game.CurrentRoom.Size.Z));

            this.Model.SetBox();
            this.Model.Size = this.Collider.Size;
            this.Model.SetTexture("floor.jpg", 15);
        }

        protected override void Step()
        { 
        }
    }
}
