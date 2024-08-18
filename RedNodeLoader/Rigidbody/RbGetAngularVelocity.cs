using System.Collections.Generic;
using System.Numerics;

namespace RedNodeLoader.UnityNodes.Rigidbody;

public class RbGetAngularVelocity : SonsNode
{
    [IsArgOut]
    public Vector3 Velocity { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        var v3 = new Vector3(rb.angularVelocity.x, rb.angularVelocity.y, rb.angularVelocity.z);
        Velocity = v3;
    }
}
