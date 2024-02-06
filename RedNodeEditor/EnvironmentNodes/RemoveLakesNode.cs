namespace RedNodeEditor.EnvironmentNodes;

public class RemoveLakesNode : SonsNode
{
    public bool Value { get; set; }

    public RemoveLakesNode()
    {
        Name = "RemoveLakes";
        Description = "Removes or restore water in all lakes";
        NodeCategory = NodeCategories.Environment;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
