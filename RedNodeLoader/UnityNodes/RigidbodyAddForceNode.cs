using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class RigidbodyAddForceNode : SonsNode
{
    [XmlIgnore]
    public Rigidbody Rigidbody { get; set; }
    public Vector3 Direction { get; set; }
    public ForceMode EnumValue { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (Rigidbody)args[0];
        var dir = (Vector3)args[1];
        rb.AddForce(new UnityEngine.Vector3(dir.X, dir.Y, dir.Z), (ForceMode)args[2]);
    }
}
