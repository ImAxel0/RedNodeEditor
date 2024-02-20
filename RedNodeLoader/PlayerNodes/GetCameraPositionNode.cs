using System.Numerics;
using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class GetCameraPositionNode : SonsNode
{
    [IsArgOut]
    public Vector3 Position { get; set; }

    public override void Execute()
    {
        var pos = LocalPlayer.MainCamTr.position;
        Position = new Vector3(pos.x, pos.y, pos.z);
    }
}
