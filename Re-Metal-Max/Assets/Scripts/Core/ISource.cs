﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReMetalMax.Core
{
    public interface ISource
    {
        string Name { get; set; }
        string Type { get; set; }
    }
}
