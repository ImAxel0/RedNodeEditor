using System.Xml.Serialization;
using UnityEngine;
using Component = UnityEngine.Component;

namespace RedNodeLoader.UnityNodes;

public class GetComponentNode : SonsNode
{
    [XmlIgnore]
    public GameObject GameObject { get; set; }
    public string ComponentName { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public Component Component { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var go = (GameObject)args[0];
        Component = go.GetComponent((string)args[1]);
    }
}
