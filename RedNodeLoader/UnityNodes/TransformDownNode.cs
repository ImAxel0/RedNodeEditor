using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class TransformDownNode : SonsNode
{
    [IsArgOut]
    public Vector3 Down { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        Down = -new Vector3(tr.up.x, tr.up.y, tr.up.z);
    }
}
