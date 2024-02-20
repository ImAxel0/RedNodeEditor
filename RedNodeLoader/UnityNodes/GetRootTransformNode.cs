using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class GetRootTransformNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public Transform RootTr { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        RootTr = tr.GetRoot();
    }
}
