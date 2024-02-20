using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class GetLocalPositionNode : SonsNode
{
    [IsArgOut]
    public Vector3 LocalPosition { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        LocalPosition = new Vector3(tr.localPosition.x, tr.localPosition.y, tr.localPosition.z);
    }
}
