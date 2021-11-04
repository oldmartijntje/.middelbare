using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_example_fps
{
    public class instance_impactfloor : Instance
    {
        //stel in dat dit voorwerp precies een seconde blijft bestaan
        int framesalive = Game.Settings.MaxFPS;

        public instance_impactfloor(uint id) : base(id)
        {
        }

        protected override void Start()
        {
            this.Model.SetSphere();
            this.Model.Size = new Vector3(0.4f, 0.1f, 0.4f);
            this.Model.SetColor(new Color(0.1f, 0.1f, 0.1f, 0.1f));
            this.Model.SetMaterial(Enums.Material.Multiply);
            this.Model.DrawShadow = false;
        }

        protected override void Step()
        {
            //laat het voorwerp op den duur verdwijnen
            this.framesalive--;

            if (this.framesalive == 0)
            {
                this.Destroy();
            }
        }
    }
}
