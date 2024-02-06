namespace RedNodeEditor.PlayerNodes;

public class ApplyHealingNode : SonsNode
{
    public float Value { get; set; }

    public ApplyHealingNode()
    {
        Name = "ApplyHealing";
        Description = "Heal the player gradually towards value";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
