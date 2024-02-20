using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class TransformForwardNode : SonsNode
{
    [IsArgOut]
    public Vector3 Forward { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        Forward = new Vector3(tr.forward.x, tr.forward.y, tr.forward.z);
    }
}
