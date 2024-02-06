namespace RedNodeEditor.PlayerNodes;

public class SetHydrationNode : SonsNode
{
    public float Value { get; set; }

    public SetHydrationNode()
    {
        Name = "SetHydration";
        Description = "Sets player hydration";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
