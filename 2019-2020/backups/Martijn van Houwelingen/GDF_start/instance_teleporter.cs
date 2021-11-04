using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_teleporter : Instance
    {
        public instance_teleporter(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetSphere(0.5f);
            this.Model.SetSphere();
            this.Model.Size = Vector3.One * 0.5f;
            this.Model.SetColor(Color.Blue);
        }

        protected override void Step()
        {
            if (this.DetectCollision(typeof(instance_player)))
            {
                

                this.Destroy();
            }
        }
    }
}
