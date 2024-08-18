using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace RedNodeLoader.UnityNodes.Rigidbody;

public class RbSetAngularVelocity : SonsNode
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public Vector3 Velocity { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        var v3 = (Vector3)args[1];
        rb.angularVelocity = new UnityEngine.Vector3(v3.X, v3.Y, v3.Z);
    }
}
