namespace RedNodeEditor.PlayerNodes;

public class SetRestNode : SonsNode
{
    public float Value { get; set; }

    public SetRestNode()
    {
        Name = "SetRest";
        Description = "Sets player rest";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
