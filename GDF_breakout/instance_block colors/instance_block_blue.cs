using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;

namespace GDF_breakout
{
    class instance_block_blue : instance_block
    {
        public instance_block_blue(uint id) : base(id) 
        {
            Kleur = "#1463ff";
        }
    }

}
