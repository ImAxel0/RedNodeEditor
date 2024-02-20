using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class RaycastHitPointNode : SonsNode
{
    [IsArgOut]
    public Vector3 Position { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var hitInfo = (RaycastHit)args[0];
        Position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
    }
}
