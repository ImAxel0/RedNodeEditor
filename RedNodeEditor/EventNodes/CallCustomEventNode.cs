namespace RedNodeEditor.EventNodes;

public class CallCustomEventNode : SonsNode
{
    [IgnoreProperty]
    public string EventId { get; set; }
    [IsEventName]
    public string EventName { get; set; }

    public CallCustomEventNode()
    {
        Name = "CallCustomEvent";
        Description = "Calls a custom event";
        NodeCategory = NodeCategories.FlowChange;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
    }
}
