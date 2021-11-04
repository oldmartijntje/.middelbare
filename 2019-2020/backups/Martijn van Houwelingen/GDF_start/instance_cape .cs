using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_cape : Instance
    {
        public instance_cape(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetSphere(0.5f);
            this.Model.SetCylinder();
            this.Model.Size = Vector3.One * 0.5f;
            this.Model.SetColor(Color.Red);
        }

        protected override void Step()
        {
            
        }
    }
}
