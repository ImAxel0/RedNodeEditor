using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class SetLocalPositionNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }

    public Vector3 xyz { get; set; }

    public SetLocalPositionNode()
    {
        Name = "SetLocalPosition";
        Description = "Sets the local position of the passed transform";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(xyz) });
    }
}
