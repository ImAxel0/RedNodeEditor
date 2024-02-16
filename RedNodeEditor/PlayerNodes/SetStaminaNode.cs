namespace RedNodeEditor.PlayerNodes;

public class SetStaminaNode : SonsNode
{
    public float Value { get; set; }

    public SetStaminaNode()
    {
        Name = "SetStamina";
        Description = "Sets the player stamina";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
