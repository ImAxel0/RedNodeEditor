namespace RedNodeEditor.PlayerNodes;

public class IsJumpingNode : SonsNode
{
    public IsJumpingNode()
    {
        Name = "IsJumping";
        Description = "Check if player is jumping";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
