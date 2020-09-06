using System;
using UnityEngine;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class PlayAnimationEvent : BaseEvent, IRePushEvent
    {
        public Action<EventContext> OnEnd { get; set; }
        private Func<EventContext, Animation> m_animationCallBack;
        private string m_animationName;
        private PlayMode m_animationPlayMode;
        private bool m_played = false;

        public PlayAnimationEvent(Func<EventContext, Animation> animationCallBack, string animationName, PlayMode animationPlayMode)
        {
            m_animationCallBack = animationCallBack;
            m_animationName = animationName;
            m_animationPlayMode = animationPlayMode;
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
            }

            m_played = true;
            animation.Play(this.m_animationName, this.m_animationPlayMode);
            context.PushToNextFrame(this);
        }

        public void StopRepush(EventContext context)
        {
            this.IsDone = true;
            OnEnd?.Invoke(context);
        }
    }
}
