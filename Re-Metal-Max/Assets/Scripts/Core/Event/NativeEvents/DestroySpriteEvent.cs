using UnityEngine;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class DestroySpriteEvent : BaseEvent
    {
        private string m_spriteName;

        public DestroySpriteEvent(string spriteName)
        {
            this.m_spriteName = spriteName;
        }

        public override void Excute(EventContext context)
        {
            base.Excute(context);
            var obj = context[this.m_spriteName];
            if (obj != null)
            {
                GameObject.Destroy(obj.gameObject);
                context.RemoveFromDict(this.m_spriteName);
            }
        }
    }
}