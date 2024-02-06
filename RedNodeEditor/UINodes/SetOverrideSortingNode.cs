namespace RedNodeEditor.UI;

public class SetOverrideSortingNode : SonsNode
{
    public string PanelId { get; set; }
    public int Value { get; set; }

    public SetOverrideSortingNode()
    {
        Name = "SetOverrideSorting";

        NodeCategory = NodeCategories.UI;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Value) });
    }
}
