using ReMetalMax.Core;
using ReMetalMax.Util;

namespace ReMetalMax.Core.Event.NativeEvents
{
    public class BGMEvent : BaseEvent
    {
        private string m_bgmName;
        private AudioManager.AudioEvent m_bgmEventType;

        public BGMEvent(string bgmName, AudioManager.AudioEvent bgmEventType)
        {
            m_bgmName = bgmName;
            m_bgmEventType = bgmEventType;
        }

        public override void Excute(EventContext context)
        {
            object param = null;
            switch (m_bgmEventType)
            {
                case AudioManager.AudioEvent.Pause:
                case AudioManager.AudioEvent.Stop:
                    break;
                case AudioManager.AudioEvent.Play:
                    param = this.m_bgmName;
                    break;
                default:
                    break;
            }

            MessageDispatcher.CoreInstance.Send(this.m_bgmEventType, param);
            this.IsDone = true;
        }
    }
}
