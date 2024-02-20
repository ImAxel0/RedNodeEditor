using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class GameObjectFindNode : SonsNode
{
    public string name { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public GameObject GameObject { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        GameObject = GameObject.Find((string)args[0]);
    }
}
