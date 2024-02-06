namespace RedNodeEditor.UI;

public class AddCheckBoxNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; }

    [IgnoreProperty]
    public string EventId { get; set; }
    [IsEventName]
    public string EventName { get; set; }

    public AddCheckBoxNode()
    {
        Name = "AddCheckBox";
        Description = $"Adds a checkbox to the panel. Outputs the panel id as a string to chain other ui elements.\n" +
            $"When the checkbox is clicked, the associated {nameof(EventName)} (CustomEvent node) will be called passing the bool value of the checkbox";
        NodeCategory = NodeCategories.UI;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Label) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventId), Hide = true });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(EventName), Hide = true });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
