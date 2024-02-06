namespace RedNodeEditor.PlayerNodes;

public class SetFullnessNode : SonsNode
{
    public float Value { get; set; }

    public SetFullnessNode()
    {
        Name = "SetFullness";
        Description = "Sets player fullnes";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
