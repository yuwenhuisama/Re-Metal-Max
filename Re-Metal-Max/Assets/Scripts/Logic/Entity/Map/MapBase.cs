using System.Collections.Generic;
using ReMetalMax.Core;
using ReMetalMax.Core.Event;
using UnityEngine;

namespace ReMetalMax.Logic.Map
{
    public abstract class MapBase : IMap
    {
        public Dictionary<Vector2Int, IMapEvent> MapEvents { get; private set; } = new Dictionary<Vector2Int, IMapEvent>();

        public virtual bool LoadFromPath(string mapPath)
        {
            return true;
        }

        public virtual bool Load()
        {
            return true;
        }

        public virtual bool Release()
        {
            return true;
        }

        public void Update()
        {
            foreach(var pair in this.MapEvents)
            {
                pair.Value.OnUpdate();
            }
        }

        public bool Initialize()
        {
            foreach (var pair in this.MapEvents)
            {
                pair.Value.Initialize();
                // 执行自动事件
                if (pair.Value.EventType == MapEventType.Auto)
                {
                    EventManager.Instance.Context.Push(pair.Value.InnerEvent);
                }
                pair.Value.OnStart();
            }
            return true;
        }
    }
}
