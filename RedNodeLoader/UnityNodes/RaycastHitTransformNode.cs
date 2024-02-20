using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class RaycastHitTransformNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public Transform Transform { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var hitInfo = (RaycastHit)args[0];
        Transform = hitInfo.transform;
    }
}
