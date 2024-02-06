namespace RedNodeEditor.PlayerNodes;

public class SetGodModeNode : SonsNode
{
    public bool Value { get; set; }

    public SetGodModeNode()
    {
        Name = "SetGodMode";
        Description = "Sets or unset player immortality";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
