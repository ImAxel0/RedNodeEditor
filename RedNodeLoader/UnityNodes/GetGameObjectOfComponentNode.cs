using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class GetGameObjectOfComponentNode : SonsNode
{
    [XmlIgnore]
    [IsArgOut]
    public GameObject GameObject { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var cmp = (Component)args[0];
        GameObject = cmp.gameObject;
    }
}
