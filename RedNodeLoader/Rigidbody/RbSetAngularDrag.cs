using System.Collections.Generic;
using System.Xml.Serialization;

namespace RedNodeLoader.UnityNodes.Rigidbody;

public class RbSetAngularDrag : SonsNode
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public float Drag { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var rb = (UnityEngine.Rigidbody)args[0];
        rb.angularDrag = (float)args[1];
    }
}
