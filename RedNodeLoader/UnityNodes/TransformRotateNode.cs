using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class TransformRotateNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }
    public Vector3 Rotation { get; set; }
    public Space EnumValue { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        var rot = (Vector3)args[1];
        tr.Rotate(new UnityEngine.Vector3(rot.X, rot.Y, rot.Z), (Space)args[2]);
    }
}
