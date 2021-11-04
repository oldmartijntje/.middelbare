using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class creepercheek : Creeper
    {
        public creepercheek(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox();
            this.Model.SetBox();
            this.Model.Size.Y = 0.9f;
            this.Model.Size.X = 0.9f;
            this.Model.Size.Z = 0.9f;
            Model.SetTexture("creeper cheek.png");
        }

        protected override void Step()
        {

        }
    }
}
