namespace RedNodeEditor.PlayerNodes;

public class GetWalkSpeedNode : SonsNode
{
    public GetWalkSpeedNode()
    {
        Name = "GetWalkSpeed";
        Description = "Returns player walk speed";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
