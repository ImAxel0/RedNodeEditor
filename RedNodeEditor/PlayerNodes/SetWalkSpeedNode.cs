namespace RedNodeEditor.PlayerNodes;

public class SetWalkSpeedNode : SonsNode
{
    public float Speed { get; set; }

    public SetWalkSpeedNode()
    {
        Name = "SetWalkSpeed";
        Description = "Sets player walk speed";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Speed) });
    }
}
