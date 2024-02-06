namespace RedNodeEditor.UI;

public class AddSeparatorNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; } = "";
    public string TextColor { get; set; } = "#ffffff";

    public AddSeparatorNode()
    {
        Name = "AddSeparator";
        Description = $"Adds an horizontal line separator as the ones in the settings menu with an optional label of the given hexademical color.\n" +
            $"Outputs the panel id as a string to chain other ui elements";
        NodeCategory = NodeCategories.UI;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Label) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(TextColor) });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
