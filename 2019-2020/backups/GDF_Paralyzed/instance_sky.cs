using GDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;

namespace GDF_example_fps
{
    public class instance_sky : Instance
    {
        public instance_sky(uint id) : base(id)
        {
        }

        protected override void Start()
        {
            this.Model.SetSphere();
            this.Model.SetTexture("sky.jpg");
            this.Model.ShowInsideFaces();
            this.Model.Size = Vector3.One * 1000;
            this.Model.DrawShadow = false;
        }

        protected override void Step()
        {
        }
    }
}
