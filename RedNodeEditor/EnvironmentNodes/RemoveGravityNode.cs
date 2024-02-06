namespace RedNodeEditor.EnvironmentNodes;

public class RemoveGravityNode : SonsNode
{
    public bool Value { get; set; }

    public RemoveGravityNode()
    {
        Name = "RemoveGravity";
        Description = "Removes or restore player gravity in world";
        NodeCategory = NodeCategories.Environment;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
