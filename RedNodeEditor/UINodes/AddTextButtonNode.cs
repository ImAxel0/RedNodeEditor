namespace RedNodeEditor.UI;

public class AddTextButtonNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; }

    [IgnoreProperty]
    public string EventId { get; set; }
    [IsEventName]
    public string EventName { get; set; }

    public AddTextButtonNode()
    {
        Name = "AddTextButton";
        Description = $"Adds a text button to the panel. When clicked the CustomEvent node of the given {nameof(EventName)} will be executed." +
            $"Outputs the panel id as a string to chain other ui elements";
        NodeCategory = NodeCategories.UI;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Label) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventId), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
