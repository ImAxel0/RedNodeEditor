namespace RedNodeEditor.UI;

public class TogglePanelNode : SonsNode
{
    public string PanelId { get; set; }
    public bool Value { get; set; }

    public TogglePanelNode()
    {
        Name = "TogglePanel";
        Description = "Shows or hide the panel of the given Id. Outputs the panel id as a string to chain other ui elements";
        NodeCategory = NodeCategories.UI;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });

        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
