using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class GetTransformNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public Transform Transform { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var go = (GameObject)args[0];
        Transform = go.transform;
    }
}
