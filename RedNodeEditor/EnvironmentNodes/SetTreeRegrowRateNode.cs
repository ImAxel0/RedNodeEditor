namespace RedNodeEditor.EnvironmentNodes;

public class SetTreeRegrowRateNode : SonsNode
{
    public float Rate { get; set; } = 0.1f;

    public SetTreeRegrowRateNode()
    {
        Name = "SetTreeRegrowRate";
        Description = "Default should be 0.1, rate must be in 0-1 range.";
        NodeCategory = NodeCategories.Environment;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Rate) });
    }
}
