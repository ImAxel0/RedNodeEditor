namespace RedNodeEditor.PlayerNodes;

public class CanRunNode : SonsNode
{
    public CanRunNode()
    {
        Name = "CanRun";
        Description = "Check if player can run";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}