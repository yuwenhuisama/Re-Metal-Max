using System.Collections.Generic;
using ReMetalMax.Core.Event;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class BaseEvent : IEvent
    {
        public bool IsDone { get; set; } = false;
        public long Frame { get; set; }

        public Dictionary<string, object> ExtraInfo => throw new System.NotImplementedException();

        public virtual void Excute(EventContext context) { }

    }
}
