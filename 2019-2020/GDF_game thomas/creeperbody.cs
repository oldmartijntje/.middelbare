using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class creeperbody : Creeper
    {
        public creeperbody(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox();
            this.Model.SetBox();
            this.Model.Size.Y = 1.5f;
            this.Model.Size.X = 0.75f;
            this.Model.Size.Z = 0.75f;
            Model.SetTexture("creeperbody.png");
        }

        protected override void Step()
        {

        }
    }
}
