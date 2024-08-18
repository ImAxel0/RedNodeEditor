using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace RedNodeLoader.UnityNodes.Rigidbody;

public class RbMove : SonsNode
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public Vector3 Pos { get; set; }
    public Vector3 Rot { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        var pos = (Vector3)args[1];
        var rot = (Vector3)args[2];
        rb.Move(new UnityEngine.Vector3(pos.X, pos.Y, pos.Z),
            UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(rot.X, rot.Y, rot.Z)));
    }
}
