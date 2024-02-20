using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class GetLocalRotationNode : SonsNode
{
    [IsArgOut]
    public Vector3 LocalRotation { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        LocalRotation = new Vector3(tr.localRotation.x, tr.localRotation.y, tr.localRotation.z);
    }
}
