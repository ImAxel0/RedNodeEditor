namespace RedNodeLoader.EventsNodes;

public class CallCustomEventNode : SonsNode
{
    public string EventId { get; set; }
    public string EventName { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        RedNodeLoader.GetCustomEvent((string)args[0]).Execute();
    }
}
