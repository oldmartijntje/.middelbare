using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_glass : Instance
    {
        public instance_glass(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox();
            this.Model.SetBox();
            Model.SetTexture("light blue.jpg");
        }

        protected override void Step()
        {

        }
    }
}
