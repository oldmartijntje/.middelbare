using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_breakout
{
    public class instance_speler : Instance
    {
        public instance_speler(uint id) : base(id) { }

        protected override void Start()
        {
            this.Model.SetBox();
            this.Model.Size = new Vector3(2.5f, 0.3f, 0.2f);
            this.Model.SetColor(Color.FromHex("#ff7605"));
            this.Collider.SetBox(this.Model.Size);
        }

        protected override void Step()
        {
            if (GetKey(Key.Left) && GetKey(Key.Shift) && _2D_DirectionFree(-90, 0.2f, typeof(instance_muurVerticaal)))
            {
                this.Position.X -= 0.30f;
            }
            else if (GetKey(Key.Left) && _2D_DirectionFree(-90, 0.1f, typeof(instance_muurVerticaal)))
            {
                this.Position.X -= 0.15f;
            }
            if (GetKey(Key.Right) && GetKey(Key.Shift) && _2D_DirectionFree(90, 0.2f, typeof(instance_muurVerticaal)))
            {
                this.Position.X += 0.30f;
            }
            else if (GetKey(Key.Right) && _2D_DirectionFree(90, 0.1f, typeof(instance_muurVerticaal)))
            {
                this.Position.X += 0.15f;
            }
        }
    }
}
