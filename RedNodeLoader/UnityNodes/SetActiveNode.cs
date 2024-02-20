using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class SetActiveNode : SonsNode
{
    [XmlIgnore]
    public GameObject GameObject { get; set; }
    public bool Value { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var go = (GameObject)args[0];
        go.SetActive((bool)args[1]);
    }
}
