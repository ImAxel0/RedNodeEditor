namespace RedNodeEditor.PlayerNodes;

public class FullArmourOfTypeNode : SonsNode
{
    public int ArmourId { get; set; }

    public FullArmourOfTypeNode()
    {
        Name = "FullArmourOfType";
        Description = "Equip player with full armour of given type";
        NodeCategory = NodeCategories.Player;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ArmourId) });
    }
}
