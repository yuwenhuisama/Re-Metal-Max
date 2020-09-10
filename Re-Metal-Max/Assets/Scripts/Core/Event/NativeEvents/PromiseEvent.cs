using System;
using System.Collections.Generic;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class PromiseEvent: BaseEvent, IRePushEvent {
        private LinkedList<Func<EventContext, PromiseEvent>> m_callbackCache = new LinkedList<Func<EventContext, PromiseEvent>>();

        public Action<EventContext> OnEnd { get; set; }
        public Action<EventContext> OnForceStoped { get; set; }

        private bool m_forceStoped = false;

        public PromiseEvent()
        {
            OnEnd = (ctx) =>
            {
                if (m_forceStoped)
                {
                    this.IsDone = true;
                    return;
                }

                if (m_callbackCache.Count > 0)
                {
                    var firstCallback = m_callbackCache.First;
                    m_callbackCache.RemoveFirst();

                    var newAnimation = firstCallback.Value.Invoke(ctx);
                    if (newAnimation != null)
                    {
                        newAnimation.m_callbackCache = m_callbackCache;

                        ctx.Push(newAnimation);
                    }
                }
                this.IsDone = true;
            };
        }

        public PromiseEvent Then(Func<EventContext, PromiseEvent> callback)
        {
            m_callbackCache.AddLast(callback);
            return this;
        }

        public virtual void StopRepush(EventContext context)
        {
            this.IsDone = true;
            m_forceStoped = true;
            this.OnForceStoped?.Invoke(context);
        }
    }
}
