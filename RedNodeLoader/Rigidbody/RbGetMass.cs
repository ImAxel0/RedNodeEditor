using System.Collections.Generic;

namespace RedNodeLoader.UnityNodes.Rigidbody;

public class RbGetMass : SonsNode
{
    [IsArgOut]
    public float Mass { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        Mass = rb.mass;
    }
}
