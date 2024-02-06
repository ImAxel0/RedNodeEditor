namespace RedNodeEditor.PlayerNodes;

public class IsRunningNode : SonsNode
{
    public IsRunningNode()
    {
        Name = "IsRunning";
        Description = "Check if player is running";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
