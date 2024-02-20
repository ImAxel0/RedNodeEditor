using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class RaycastHitDistanceNode : SonsNode
{
    [IsArgOut]
    public float Distance { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var hitInfo = (RaycastHit)args[0];
        Distance = hitInfo.distance;
    }
}
