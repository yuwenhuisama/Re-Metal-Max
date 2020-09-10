using System;

namespace ReMetalMax.Core.Event
{
    class EventManager
    {
        public readonly static EventManager Instance = new EventManager();
        private EventManager() { }

        public EventContext Context { get; private set; } = new EventContext();

        public void Update()
        {
            var newEvent = this.Context.FrontEvent;
            while (newEvent != null && this.Context.FrameCount == newEvent.Frame) 
            {
                this.Context.Pop();
                newEvent.Excute(this.Context);
                newEvent = this.Context.FrontEvent;
            }

            this.Context.UpdateFrame();

            // const int maxHandlerEvent = 10;

            // var handleCount = Math.Min(this.Context.EventCount, maxHandlerEvent);

            // for (int i = 0; i < handleCount; ++i)
            // {
            //     var newEvent = Context.Pop();
            //     newEvent.Excute(Context);
            // }
        }
    }
}