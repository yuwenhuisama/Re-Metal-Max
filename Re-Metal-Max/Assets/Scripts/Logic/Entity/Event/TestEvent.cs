using ReMetalMax.Core.Event;
using ReMetalMax.Core.Event.NativeEvents;

namespace ReMetalMax.Logic.Entity.Event
{
    class TestEvent: EventBase
    {
        public override void Excute(EventContext context)
        {
            context.Push(new InputStateEvent(InputStateEvent.InputState.Ignore));

            context.Push(new InputStateEvent(InputStateEvent.InputState.NoIgnore));
        }
    }
}