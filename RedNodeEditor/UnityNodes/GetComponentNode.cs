using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class GetComponentNode : SonsNode
{
    [XmlIgnore]
    public GameObject GameObject { get; set; }
    public string ComponentName { get; set; }

    public GetComponentNode()
    {
        Name = "GetComponent";
        Description = "Gets a component of the passed GameObject by name";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(GameObject), ArgName = nameof(GameObject) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(ComponentName) });
        ArgsOut.Add(new ArgOut { Type = typeof(Component) });
    }
}
