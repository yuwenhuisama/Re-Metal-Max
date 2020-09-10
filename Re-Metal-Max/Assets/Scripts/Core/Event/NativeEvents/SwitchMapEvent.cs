using ReMetalMax.Core.Event.NativeEvents;

namespace ReMetalMax.Core.Event
{
    public class SwitchMapEvent : PromiseEvent
    {
        private IMap m_targeMap;

        public SwitchMapEvent(IMap targetMap) : base()
        {
            m_targeMap = targetMap;
        }

        public override void Excute(EventContext context)
        {
            MapManager.Instance.Switch(m_targeMap);
            this.IsDone = true;
        }
    }
}