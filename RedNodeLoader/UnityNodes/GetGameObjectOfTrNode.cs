using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class GetGameObjectOfTrNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public GameObject GameObject { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        GameObject = tr.gameObject;
    }
}
