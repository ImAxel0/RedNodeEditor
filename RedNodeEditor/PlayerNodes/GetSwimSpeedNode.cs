namespace RedNodeEditor.PlayerNodes;

public class GetSwimSpeedNode : SonsNode
{
    public GetSwimSpeedNode()
    {
        Name = "GetSwimSpeed";
        Description = "Returns player swim speed";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
