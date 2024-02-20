using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class SetLocalRotationNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }

    public Vector3 Rotation { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        var rot = (Vector3)args[1];
        tr.localRotation.SetEulerAngles(rot.X, rot.Y, rot.Z);
    }
}
