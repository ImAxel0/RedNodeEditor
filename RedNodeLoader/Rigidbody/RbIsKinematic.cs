using System.Collections.Generic;

namespace RedNodeLoader.UnityNodes.Rigidbody;

public class RbIsKinematic : SonsNode
{
    [IsArgOut]
    public bool IsKinematic { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        IsKinematic = rb.isKinematic;
    }
}
