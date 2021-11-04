using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class creeperfoot : Creeper
    {
        public creeperfoot(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox();
            this.Model.SetBox();
            this.Model.Size.Y = 0.75f;
            this.Model.Size.X = 0.5f;
            this.Model.Size.Z = 0.85f;
            Model.SetTexture("creeperfoot.png");
        }

        protected override void Step()
        {

        }
    }
}
