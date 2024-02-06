namespace RedNodeEditor.PlayerNodes;

public class GetRunSpeedNode : SonsNode
{
    public GetRunSpeedNode()
    {
        Name = "GetRunSpeed";
        Description = "Returns player run speed";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
