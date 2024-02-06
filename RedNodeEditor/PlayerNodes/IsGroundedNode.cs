namespace RedNodeEditor.PlayerNodes;

public class IsGroundedNode : SonsNode
{
    public IsGroundedNode()
    {
        Name = "IsGrounded";
        Description = "Check if player is grounded";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
