using ReMetalMax.Core;
using ReMetalMax.Core.Event;
using UnityEngine;

namespace ReMetalMax.Logic.MapEvent
{
    public class MapEventBase : IMapEvent
    {
        public long ID { get; private set; } = 0;

        public Vector3 AbsolutePosition { get; private set; } = Vector3.zero;
        public Vector3Int LogicPosition { get; private set;} = Vector3Int.zero;
        public IEvent InnerEvent { get; private set; } = null;
        public MapEventType EventType { get; private set; } = MapEventType.Trigger;

        public void Initialize()
        {
            this.InnerEvent.ExtraInfo[Consts.MapEvent] = this;
        }

        public void OnDestroy()
        {
            throw new System.NotImplementedException();
        }

        public void OnStart()
        {
            throw new System.NotImplementedException();
        }

        public void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}
