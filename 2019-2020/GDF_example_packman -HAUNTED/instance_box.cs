using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_pacman
{
    public class instance_box : Instance
    {
        public instance_box(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox(new Vector3(1, 1, 1));
            this.Model.SetBox();
            this.Model.Size = new Vector3(1, 1, 1);
            this.Model.SetColor(Color.Blue);
        }

        protected override void Step()
        {
        }
    }
}
