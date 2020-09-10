using System.Collections.Generic;
using UnityEngine;

namespace ReMetalMax.Core
{
    public interface IMap
    {
        Dictionary<Vector2Int, IMapEvent> MapEvents { get; }

        bool Load();
        bool Initialize();
        bool Release();

        void Update();
    }
}