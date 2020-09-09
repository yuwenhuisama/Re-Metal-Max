using System.Collections.Generic;
using ReMetalMax.Core;
using UnityEngine;

namespace ReMetalMax.Logic.Map
{
    abstract class MapBase : IMap
    {
        public Dictionary<Vector3, IMapEvent> MapEvents { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public virtual bool LoadFromPath(string mapPath)
        {
            return true;
        }

        public virtual bool Load()
        {
            throw new System.NotImplementedException();
        }

        public virtual bool Release()
        {
            throw new System.NotImplementedException();
        }
    }
}
