using System;

namespace ReMetalMax.Core.Event
{
    public interface IRePushEvent
    {
        Action<EventContext> OnForceStoped { get; set; }
        void StopRepush(EventContext context);
    }
}