using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_pacman
{
    public class instance_teleport : Instance
    {
        public instance_teleport(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox(new Vector3(0.01f, 3, 3));
            this.Model.SetBox();
            this.Model.Size = new Vector3(0.01f, 3, 3);
            this.Model.SetTexture("teleport.jpg");
        }

        protected override void Step()
        {
            
        }

        
    }
}
