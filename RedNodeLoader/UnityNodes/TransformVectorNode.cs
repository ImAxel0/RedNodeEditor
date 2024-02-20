using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.UnityNodes;

public class TransformVectorNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }
    public Vector3 LocalVec3 { get; set; }

    [IsArgOut]
    public Vector3 WorldVec3 { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        var localVec3 = (Vector3)args[1];
        var uWorldVec3 = tr.TransformVector(new UnityEngine.Vector3(localVec3.X, localVec3.Y, localVec3.Z));
        WorldVec3 = new Vector3(uWorldVec3.x, uWorldVec3.y, uWorldVec3.z);
    }
}
