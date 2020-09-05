namespace ReMetalMax.Core.Event
{
    public interface IEvent
    {
        bool IsDone { get; }
        void Excute(EventContext context);
    }
}
