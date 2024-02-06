namespace RedNodeEditor.EnvironmentNodes;

public class SetTimeMultiplierNode : SonsNode
{
    public float Multiplier { get; set; }

    public SetTimeMultiplierNode()
    {
        Name = "SetTimeMultiplier";
        Description = "Multiplies the game time speed by the given value";
        NodeCategory = NodeCategories.Environment;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Multiplier) });
    }
}
