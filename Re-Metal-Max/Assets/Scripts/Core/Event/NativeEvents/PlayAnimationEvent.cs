using System;
using System.Collections.Generic;
using UnityEngine;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class PlayAnimationEvent : BaseEvent, IRePushEvent
    {
        public Action<EventContext> OnEnd { get; set; }
        public Action<EventContext> OnForceStoped { get; set; }

        private Func<EventContext, Animation> m_animationCallBack;
        private string m_animationName;
        private PlayMode m_animationPlayMode;
        private bool m_played = false;
        private bool m_forceStoped = false;

        private LinkedList<Func<EventContext, PlayAnimationEvent>> m_callbackCache = new LinkedList<Func<EventContext, PlayAnimationEvent>>();

        public PlayAnimationEvent(Func<EventContext, Animation> animationCallBack, string animationName, PlayMode animationPlayMode)
        {
            m_animationCallBack = animationCallBack;
            m_animationName = animationName;
            m_animationPlayMode = animationPlayMode;

            OnEnd = (ctx) =>
            {
                if (m_forceStoped)
                {
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
            };
        }

        public override void Excute(EventContext context)
        {
            if (this.IsDone)
            {
                return;
            }

            var animation = m_animationCallBack.Invoke(context);
            if (animation)
            {
                if (m_played && !animation.isPlaying)
                {
                    this.IsDone = true;
                    OnEnd?.Invoke(context);
                    return;
                }
                else
                {
                    context.PushToNextFrame(this);
                }
            }
            else
            {
                this.IsDone = true;
                OnEnd?.Invoke(context);
                return;
            }

            m_played = true;
            animation.Play(this.m_animationName, this.m_animationPlayMode);
            context.PushToNextFrame(this);
        }

        public void StopRepush(EventContext context)
        {
            this.IsDone = true;
            m_forceStoped = true;
            // OnEnd?.Invoke(context);
            OnForceStoped(context);
        }

        public PlayAnimationEvent Then(Func<EventContext, PlayAnimationEvent> callback)
        {
            m_callbackCache.AddLast(callback);
            return this;
        }
    }
}
