using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class InstantiateObjectNode : SonsNode
{
    [XmlIgnore]
    public GameObject GameObject { get; set; }
    public Vector3 Pos { get; set; }
    public Vector3 Rot { get; set; }

    public InstantiateObjectNode()
    {
        Name = "InstantiateObject";
        Description = "Instantiate the passed GameObject at the given position and rotation";
        NodeCategory = NodeCategories.Unity;
        
        ArgsIn.Add(new ArgIn { Type = typeof(GameObject), ArgName = nameof(GameObject) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Pos) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Rot) });
    }
}
