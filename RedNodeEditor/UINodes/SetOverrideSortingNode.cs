namespace RedNodeEditor.UINodes;

public class SetOverrideSortingNode : SonsNode
{
    public string PanelId { get; set; }
    public int Value { get; set; }

    public SetOverrideSortingNode()
    {
        Name = "SetOverrideSorting";
        Description = "Sets the Z order of the panel. Panels with higher number will display above panels having lower number";
        NodeCategory = NodeCategories.UI;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Value) });
    }
}
