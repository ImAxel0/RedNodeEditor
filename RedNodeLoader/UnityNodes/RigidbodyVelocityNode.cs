using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class RigidbodyVelocityNode : SonsNode
{
    [IsArgOut]
    public Vector3 Velocity { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (Rigidbody)args[0];
        Velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
    }
}
