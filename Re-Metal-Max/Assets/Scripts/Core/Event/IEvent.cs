namespace ReMetalMax.Core.Event
{
    public interface IEvent
    {
        bool IsDone { get; }
        long Frame { get; set; }

        void Excute(EventContext context);
    }
}
