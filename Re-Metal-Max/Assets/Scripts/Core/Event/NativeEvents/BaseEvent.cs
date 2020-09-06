using ReMetalMax.Core.Event;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class BaseEvent : IEvent
    {
        public bool IsDone { get; set; } = false;
        public long Frame { get; set; }

        public virtual void Excute(EventContext context) { }

    }
}
