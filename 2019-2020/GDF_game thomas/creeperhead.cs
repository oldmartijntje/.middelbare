using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class creepherhead : Creeper
    {
        public creepherhead(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox();
            this.Model.SetBox();
            this.Model.Size.Y = 0.9f;
            this.Model.Size.X = 0.9f;
            this.Model.Size.Z = 0;
            Model.SetTexture("creeperhead.png");
        }

        protected override void Step()
        {

        }
    }
}
