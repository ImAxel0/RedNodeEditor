using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class RigidbodySetKinematicNode : SonsNode
{
    [XmlIgnore]
    public Rigidbody Rigidbody { get; set; }
    public bool Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (Rigidbody)args[0];
        rb.isKinematic = (bool)args[1];
    }
}
