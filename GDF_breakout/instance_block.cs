using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_breakout
{
    public class instance_block: Instance
    {
        public instance_block(uint id) : base(id) { }
        public string Kleur = "#1463ff";

        protected override void Start()
        {
            this.Model.SetSphere();
            this.Model.Size = Vector3.One * 0.3f;
            this.Model.SetColor(Color.FromHex(this.Kleur));
            this.Collider.SetSphere(0.3f);

        }
        protected override void Step()
        {
        }
    }
}
