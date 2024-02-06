namespace RedNodeEditor.PlayerNodes;

public class IsConnectedToLogSledNode : SonsNode
{
    public IsConnectedToLogSledNode()
    {
        Name = "IsConnectedToSlogSled";
        Description = "Check if player is using log sled";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
