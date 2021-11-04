using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class room_main : Room
    {
        public room_main(string name) : base(name) { }

        protected override void Start()
        {
            this.InstanceCreate(0, 0.5f, 0, typeof(instance_block));
        }

        protected override void Step()
        {
            if(Game.Input.GetKey(Urho.Key.Esc))
            {
                Game.Exit();
            }
        }
    }
}
