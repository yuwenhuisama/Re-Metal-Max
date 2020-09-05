using ReMetalMax.Core.Event;
using ReMetalMax.Core.Event.NativeEvents;
using UnityEngine;

namespace ReMetalMax.Logic.SceneEvents
{
    class OpenSceneEvent : IEvent
    {
        public bool IsDone { get; private set; }

        private Animation m_animation;

        public OpenSceneEvent(Animation animation)
        {
            m_animation = animation;
        }

        public void Excute(EventContext context)
        {
            context.Push(new PlayAnimationEvent(this.m_animation, "open", PlayMode.StopAll)
            {
                OnEnd = () => { Debug.Log("OnEnd"); },
            });
        }
    }
}