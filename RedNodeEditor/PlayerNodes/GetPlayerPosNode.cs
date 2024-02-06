using System.Numerics;

namespace RedNodeEditor.PlayerNodes;

public class GetPlayerPosNode : SonsNode
{
    public GetPlayerPosNode()
    {
        Name = "GetPlayerPos";
        Description = "Returns player position as Vector3";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
