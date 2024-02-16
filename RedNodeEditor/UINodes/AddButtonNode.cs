namespace RedNodeEditor.UINodes;

public class AddButtonNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; }

    [IgnoreProperty]
    public string EventId { get; set; }
    [IsEventName]
    public string EventName { get; set; }

    public AddButtonNode()
    {
        Name = "AddButton";
        Description = $"Adds a button to the panel. When clicked the CustomEvent node of the given {nameof(EventName)} will be executed." +
            $"Outputs the panel id as a string to chain other ui elements";
        NodeCategory = NodeCategories.UI;
        SizeOverride = new(280, 250);

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Label) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventId), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
