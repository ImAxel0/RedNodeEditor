using System.Numerics;
using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class GetCameraForwardNode : SonsNode
{
    [IsArgOut]
    public Vector3 Forward { get; set; }

    public override void Execute()
    {
        var pos = LocalPlayer.MainCamTr.forward;
        Forward = new Vector3(pos.x, pos.y, pos.z);
    }
}
