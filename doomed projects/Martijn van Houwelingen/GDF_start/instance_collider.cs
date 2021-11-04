using GDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_collider : Instance
    {
        public instance_collider(uint id) : base(id)
        {
        }

        protected override void Start()
        {
            this.Model.Delete();
            this.Collider.SetBox();
        }

        protected override void Step()
        {
        }
    }
}
