using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class RaycastHitRigidbodyNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public Rigidbody Rigidbody { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var hitInfo = (RaycastHit)args[0];
        Rigidbody = hitInfo.rigidbody;
    }
}
