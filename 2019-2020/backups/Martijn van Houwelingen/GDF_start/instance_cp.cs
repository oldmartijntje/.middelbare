using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_cp : Instance
    {
        public instance_cp(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetSphere(0.5f);
            this.Model.SetSphere();
            this.Model.Size = Vector3.One * 0.5f;
            this.Model.SetColor(Color.White);
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
