using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_breakout
{
    public class instance_muurVerticaal : Instance
    {
        public instance_muurVerticaal(uint id) : base(id) { }

        protected override void Start()
        {
            this.Model.SetBox();
            this.Model.Size = new Vector3(1, 1, 20);
            this.Model.SetTexture("crate.jpg", 10);
            this.Collider.SetBox(this.Model.Size);
        }

        protected override void Step()
        {
        }
    }
}
