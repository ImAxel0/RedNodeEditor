using System.Collections.Generic;
using System.Xml.Serialization;

namespace RedNodeLoader.UnityNodes.Rigidbody;

public class RbSetMass : SonsNode
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public float Mass { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        rb.mass = (float)args[1];
    }
}
