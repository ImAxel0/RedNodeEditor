using System.Numerics;

namespace RedNodeEditor.PlayerNodes;

public class GetCameraPositionNode : SonsNode
{
    public GetCameraPositionNode()
    {
        Name = "GetCameraPosition";
        Description = "Returns player camera position as Vector3";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
