﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    public class TargetOutOfRangeException: Exception
    {
        public override string Message => "Target out of range";
    }
}
