namespace RedNodeEditor.EnvironmentNodes;

public class RemoveOceanNode : SonsNode
{
    public bool Value { get; set; }

    public RemoveOceanNode()
    {
        Name = "RemoveOcean";
        Description = "Removes or restore water in the ocean";
        NodeCategory = NodeCategories.Environment;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
