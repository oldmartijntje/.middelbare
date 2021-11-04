using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_longblock : Instance
    {
        public instance_longblock (uint id) : base(id) { }

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
