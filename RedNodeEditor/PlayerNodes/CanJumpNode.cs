namespace RedNodeEditor.PlayerNodes;

public class CanJumpNode : SonsNode
{
    public CanJumpNode()
    {
        Name = "CanJump";
        Description = "Check if player can jump";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
