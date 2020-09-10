using UnityEngine;
using ReMetalMax.Core.Event;

namespace ReMetalMax.Core
{
    public interface IMapEvent
    {
        // 事件全局ID
        long ID { get; }

        // 像素坐标
        Vector3 AbsolutePosition { get; set; }

        // 相对于地图Tile的逻辑坐标
        Vector3Int LogicPosition { get; set; }

        // 携带的可执行的Event
        IEvent InnerEvent { get; set; }

        void OnStart();

        void OnUpdate();

        void OnDestroy();
    }
}