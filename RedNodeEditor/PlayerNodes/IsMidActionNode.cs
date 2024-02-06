namespace RedNodeEditor.PlayerNodes;

public class IsMidActionNode : SonsNode
{
    public IsMidActionNode()
    {
        Name = "IsMidAction";
        Description = "Check if player is mid action (e.g is attacking)";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
