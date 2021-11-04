using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_block : Instance
    {
        public instance_block(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox();
            this.Model.SetBox();
            Model.SetTexture("crate.jpg");
        }

        protected override void Step()
        {

        }
    }
}
