namespace ReMetalMax.Core.Event
{
    class EventManager
    {
        public readonly static EventManager Instance = new EventManager();
        private EventManager() { }

        private EventContext m_context = new EventContext();

        public void Update()
        {
            var newEvent = m_context.Pop();
            while (newEvent != null)
            {
                newEvent.Excute(m_context);
            }
        }
    }
}