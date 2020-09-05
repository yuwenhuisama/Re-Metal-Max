using System;
using ReMetalMax.Core.Event;
using UnityEngine;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class PlayAnimationEvent : IEvent, IRePushEvent
    {
        public Action OnEnd { get; set; }

        public bool IsDone { get; set; }

        private Animation m_animation;
        private string m_animationName;
        private PlayMode m_animationPlayMode;
        private bool m_played = false;

        public PlayAnimationEvent(Animation animation, string animationName, PlayMode animationPlayMode)
        {
            m_animation = animation;
            m_animationName = animationName;
            m_animationPlayMode = animationPlayMode;
        }

        public void Excute(EventContext context)
        {
            if (this.IsDone)
            {
                return;
            }

            if (this.m_animation.isPlaying) {
                if (m_played)
                {
                    IsDone = true;
                    OnEnd?.Invoke();
                }
                else
                {
                    context.Push(this);
                }
                return;
            }

            m_played = true;
            this.m_animation.Play(this.m_animationName, this.m_animationPlayMode);
            context.Push(this);
        }

        public void StopRepush()
        {
            this.IsDone = true;
        }
    }
}
