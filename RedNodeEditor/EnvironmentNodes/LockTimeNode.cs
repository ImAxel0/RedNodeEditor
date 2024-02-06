namespace RedNodeEditor.EnvironmentNodes;

public class LockTimeNode : SonsNode
{
    public bool Value { get; set; }

    public LockTimeNode()
    {
        Name = "LockTime";
        Description = "Locks or unlock the game time";
        NodeCategory = NodeCategories.Environment;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
