namespace RedNodeEditor.PlayerNodes;

public class SetStrengthNode : SonsNode
{
    public float Value { get; set; }

    public SetStrengthNode()
    {
        Name = "SetStrength";
        Description = "Sets the player strength";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
