using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class GetParentNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public Transform ParentTr { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        ParentTr = tr.GetParent();
    }
}
