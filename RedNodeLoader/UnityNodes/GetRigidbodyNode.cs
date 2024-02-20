using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class GetRigidbodyNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public Rigidbody rb { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        rb = tr.GetComponent<Rigidbody>();
    }
}
