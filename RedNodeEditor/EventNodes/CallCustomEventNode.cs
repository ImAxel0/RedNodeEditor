using IconFonts;

namespace RedNodeEditor.EventNodes;

public class CallCustomEventNode : SonsNode
{
    [IgnoreProperty]
    public string EventId { get; set; }
    [IsEventName]
    public string EventName { get; set; }

    public CallCustomEventNode()
    {
        Name = $"CallCustomEvent {FontAwesome6.SquarePhone}";
        Description = "Calls a custom event";
        NodeCategory = NodeCategories.FlowChange;
        SizeOverride = new(270, 130);

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
    }
}
