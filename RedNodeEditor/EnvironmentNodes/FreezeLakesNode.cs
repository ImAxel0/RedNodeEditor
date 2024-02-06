namespace RedNodeEditor.EnvironmentNodes;

public class FreezeLakesNode : SonsNode
{
    public bool Value { get; set; }

    public FreezeLakesNode()
    {
        Name = "FreezeLakes";
        Description = "Freezes or unfrezes all freezable lakes";
        NodeCategory = NodeCategories.Environment;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
