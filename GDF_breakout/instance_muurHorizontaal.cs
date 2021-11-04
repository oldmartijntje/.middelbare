using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_breakout
{
    public class instance_muurHorizontaal: Instance
    {
        public instance_muurHorizontaal(uint id) : base(id) { }

        protected override void Start()
        {
            this.Model.SetBox();
            this.Model.Size = new Vector3(21, 1, 1);
            this.Model.SetTexture("crate.jpg", 1, 10);
            this.Collider.SetBox(this.Model.Size);
        }

        protected override void Step()
        {
        }
    }
}
