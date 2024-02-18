using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class GetComponentInChildrenNode : SonsNode
{
    [XmlIgnore]
    public GameObject GameObject { get; set; }
    public string ComponentName { get; set; }

    public GetComponentInChildrenNode()
    {
        Name = "GetComponentInChildren";
        Description = "Gets a component of one children of the passed GameObject by name. Resource intensive as bad implemented. Don't call continuosly! " +
            "Implementation may change in future";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(GameObject), ArgName = nameof(GameObject) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(ComponentName) });
        ArgsOut.Add(new ArgOut { Type = typeof(Component) });
    }
}
