using System.Collections.Generic;
using ReMetalMax.Core;
using UnityEngine;

namespace ReMetalMax.Logic.Map
{
    public class TestMap : MapBase
    {
        public override bool Load()
        {
            return this.LoadFromPath("Maps/testmap.map");
        }
    }
}