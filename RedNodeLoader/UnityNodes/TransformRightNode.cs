using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class TransformRightNode : SonsNode
{
    [IsArgOut]
    public Vector3 Right { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        Right = new Vector3(tr.right.x, tr.right.y, tr.right.z);
    }
}
