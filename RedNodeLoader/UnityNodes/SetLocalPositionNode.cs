using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class SetLocalPositionNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }

    public Vector3 xyz { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        var pos = (Vector3)args[1];
        tr.localPosition = new UnityEngine.Vector3(pos.X, pos.Y, pos.Z);
    }
}
