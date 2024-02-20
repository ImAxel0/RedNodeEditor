using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class TransformLeftNode : SonsNode
{
    [IsArgOut]
    public Vector3 Left { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        Left = -new Vector3(tr.right.x, tr.right.y, tr.right.z);
    }
}
