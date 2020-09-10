using UnityEngine;
using ReMetalMax.Core.Event;

namespace ReMetalMax.Core
{
    public enum MapEventType
    {
        Auto,
        Trigger,
    }

    public interface IMapEvent
    {
        // 事件全局ID
        long ID { get; }

        // 像素坐标
        Vector3 AbsolutePosition { get; }

        // 相对于地图Tile的逻辑坐标
        Vector3Int LogicPosition { get; }

        // 携带的可执行的Event
        IEvent InnerEvent { get; }

        // 事件类型
        MapEventType EventType { get; }

        void Initialize();

        void OnStart();

        void OnUpdate();

        void OnDestroy();
    }
}