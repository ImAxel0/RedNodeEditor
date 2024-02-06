namespace RedNodeEditor.PlayerNodes;

public class SetInfiniteStaminaNode : SonsNode
{
    public bool Value { get; set; }

    public SetInfiniteStaminaNode()
    {
        Name = "SetInfiniteStamina";
        Description = "Sets or unset player infinite stamina";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
