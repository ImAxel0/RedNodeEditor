namespace RedNodeEditor.PlayerNodes;

public class SetSwimSpeedNode : SonsNode
{
    public float Speed { get; set; }

    public SetSwimSpeedNode()
    {
        Name = "SetSwimSpeed";
        Description = "Sets player swim speed";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Speed) });
    }
}
