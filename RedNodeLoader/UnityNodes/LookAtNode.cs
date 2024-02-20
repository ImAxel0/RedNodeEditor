using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class LookAtNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }

    public Vector3 LookDirection { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        var direction = (Vector3)args[1];
        tr.LookAt(new UnityEngine.Vector3(direction.X, direction.Y, direction.Z));
    }
}
