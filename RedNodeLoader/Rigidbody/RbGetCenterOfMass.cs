using System.Collections.Generic;
using System.Numerics;

namespace RedNodeLoader.UnityNodes.Rigidbody;

public class RbGetCenterOfMass : SonsNode
{
    [IsArgOut]
    public Vector3 Center { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        var v3 = new Vector3(rb.centerOfMass.x, rb.centerOfMass.y, rb.centerOfMass.z);
        Center = v3;
    }
}
