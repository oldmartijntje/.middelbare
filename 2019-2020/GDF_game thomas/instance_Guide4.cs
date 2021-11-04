using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_Guide4 : Instance
    {
        public instance_Guide4(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox();
            this.Model.SetBox();
            Model.SetTexture("guide 1.png");
        }

        protected override void Step()
        {

        }
    }
}
