namespace RedNodeEditor.EnvironmentNodes;

public class RemoveWaterfallsNode : SonsNode
{
    public bool Value { get; set; }

    public RemoveWaterfallsNode()
    {
        Name = "RemoveWaterfalls";
        Description = "Removes or restore all waterfalls in world";
        NodeCategory = NodeCategories.Environment;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
