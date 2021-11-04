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
            Collider.Visible = false;
            this.Collider.SetBox();
            this.Model.SetBox();
            this.Model.SetTexture("ground.png");
        }

        protected override void Step()
        {
        }
    }
}
