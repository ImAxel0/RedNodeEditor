namespace RedNodeEditor.UINodes;

public class AddTextNode : SonsNode
{
    public string PanelId { get; set; }
    public string Label { get; set; }
    public int FontSize { get; set; } = 18;
    public string Color { get; set; } = "#ffffff";

    public AddTextNode()
    {
        Name = "AddText";
        Description = $"Adds a text to the panel of the given hexadecimal color. Outputs the panel id as a string to chain other ui elements";
        NodeCategory = NodeCategories.UI;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Label) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(FontSize) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Color) });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
