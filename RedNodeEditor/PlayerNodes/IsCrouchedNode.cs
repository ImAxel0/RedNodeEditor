namespace RedNodeEditor.PlayerNodes;

public class IsCrouchedNode : SonsNode
{
    public IsCrouchedNode()
    {
        Name = "IsCrouched";
        Description = "Check if player is crouched";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
