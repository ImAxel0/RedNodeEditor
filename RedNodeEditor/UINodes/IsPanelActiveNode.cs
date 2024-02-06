namespace RedNodeEditor.UI;

public class IsPanelActiveNode : SonsNode
{
    public string PanelId { get; set; }

    public IsPanelActiveNode()
    {
        Name = "IsPanelActive";
        Description = "Check if the panel of the given Id is showing or not. Outputs the panel id as a string to chain other ui elements";
        NodeCategory = NodeCategories.UI;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PanelId) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
