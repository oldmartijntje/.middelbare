using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_pacman
{
    public class instance_player_bottom : Instance
    {
        public instance_player_bottom(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetSphere(1.8f);
            
            this.Model.Size = new Vector3(0.7f, 0.7f, 0.7f);
            this.Model.SetColor(Color.Yellow);
            this.FacingDirection = new Vector3(180, 0, 0);
        }

        protected override void Step()
        {  
        }
    }
}

