namespace RedNodeEditor.PlayerNodes;

public class SetHealthNode : SonsNode
{
    public float Value { get; set; }

    public SetHealthNode()
    {
        Name = "SetHealth";
        Description = "Sets player health";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
