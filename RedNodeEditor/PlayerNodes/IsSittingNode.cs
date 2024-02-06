namespace RedNodeEditor.PlayerNodes;

public class IsSittingNode : SonsNode
{
    public IsSittingNode()
    {
        Name = "IsSitting";
        Description = "Check if player is sitting";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
