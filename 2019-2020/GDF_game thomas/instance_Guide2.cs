﻿using GDF;
using Urho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDF_start
{
    public class instance_Guide2 : Instance
    {
        public instance_Guide2(uint id) : base(id) { }

        protected override void Start()
        {
            this.Collider.SetBox();
            this.Model.SetBox();
            this.Model.Size.Z = 0;
            Model.SetTexture("guide 2.png");
        }

        protected override void Step()
        {

        }
    }
}
