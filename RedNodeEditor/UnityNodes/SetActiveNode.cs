using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class SetActiveNode : SonsNode
{
    [XmlIgnore]
    public GameObject GameObject { get; set; }
    public bool Value { get; set; }

    public SetActiveNode()
    {
        Name = "SetActive";
        Description = "Turns the passed GameObject on or off";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(GameObject), ArgName = nameof(GameObject) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
