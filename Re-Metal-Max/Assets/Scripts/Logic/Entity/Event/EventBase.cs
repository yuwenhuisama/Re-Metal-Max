using ReMetalMax.Core.Event;

namespace ReMetalMax.Logic.Entity.Event
{
    class EventBase : IEvent
    {
        public bool IsDone { get; private set; }

        public long Frame { get; set; }

        public virtual void Excute(EventContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}