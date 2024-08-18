using System.Collections.Generic;

namespace RedNodeLoader.UnityNodes.Rigidbody;

public class RbGetDrag : SonsNode
{
    [IsArgOut]
    public float Drag { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        Drag = rb.drag;
    }
}
