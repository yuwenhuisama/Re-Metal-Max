using System.Collections.Generic;
using UnityEngine;

namespace ReMetalMax.Core
{
    public interface IMap
    {
        Dictionary<Vector3, IMapEvent> MapEvents { get; set; }

        bool Load();
        bool Release();

        void Update();
    }
}