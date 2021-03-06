using System;
using UnityEngine;
using ReMetalMax.Core.Event;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class DelayEvent : PromiseEvent
    {
        private float m_time = 0.0f;
        Action<EventContext> m_callback;

        public DelayEvent(float time, Action<EventContext> callback)
        {
            m_time = time;
            m_callback = callback;
        }

        public override void Excute(EventContext context)
        {
            if (this.IsDone)
            {
                return;
            }

            this.m_time -= Time.deltaTime;
            if (this.m_time <= 0)
            {
                m_callback?.Invoke(context);
                this.IsDone = true;
            }
            else
            {
                context.PushToNextFrame(this);
            }
        }
    }
}
