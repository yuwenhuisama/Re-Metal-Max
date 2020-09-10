using System.Collections.Generic;

namespace ReMetalMax.Core.Event
{
    public interface IEvent
    {
        bool IsDone { get; }
        long Frame { get; set; }
        Dictionary<string, object> ExtraInfo { get; }

        void Excute(EventContext context);
    }
}
