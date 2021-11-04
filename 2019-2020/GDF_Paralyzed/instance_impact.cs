using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_example_fps
{
    public class instance_impact : Instance
    {
        public instance_impact(uint id) : base(id)
        {
        }

        protected override void Start()
        {
            this.Model.SetSphere();
            this.Model.Size = Vector3.One * 0.5f;
            this.Model.SetColor(Color.Yellow);
            this.Model.SetMaterial(Enums.Material.Add);
            this.Model.DrawShadow = false;
        }

        protected override void Step()
        {
            this.Destroy();
        }
    }
}
