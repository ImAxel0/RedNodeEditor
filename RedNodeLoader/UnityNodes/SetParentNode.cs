using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class SetParentNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }

    [XmlIgnore]
    public Transform NewParent { get; set; }

    public bool WorldPositionStays { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        var newParent = (Transform)args[1];
        tr.SetParent(newParent, (bool)args[2]);
    }
}
