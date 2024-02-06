namespace RedNodeEditor.PlayerNodes;

public class SetJumpMultiplierNode : SonsNode
{
    public float Value { get; set; }

    public SetJumpMultiplierNode()
    {
        Name = "SetJumpMultiplier";
        Description = "Jump multiplier of the player";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
