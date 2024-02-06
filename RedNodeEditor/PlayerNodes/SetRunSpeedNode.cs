namespace RedNodeEditor.PlayerNodes;

public class SetRunSpeedNode : SonsNode
{
    public float Speed { get; set; }

    public SetRunSpeedNode()
    {
        Name = "SetRunSpeed";
        Description = "Sets player run speed";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Speed) });
    }
}
