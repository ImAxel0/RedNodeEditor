using System.Numerics;

namespace RedNodeEditor.PlayerNodes;

public class GetCameraForwardNode : SonsNode
{
    public GetCameraForwardNode()
    {
        Name = "GetCameraForward";
        Description = "Returns player camera forward direction as Vector3";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
