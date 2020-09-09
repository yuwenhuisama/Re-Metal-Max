namespace ReMetalMax.Core.Event.NativeEvents
{
    public class InputStateEvent : BaseEvent {
        public enum InputState
        {
            Ignore,
            NoIgnore,
        }

        InputState m_state;

        public InputStateEvent(InputState state)
        {
            m_state = state;
        }

        public override void Excute(EventContext context)
        {
            //TODO: forbid all input
        }
    }
}