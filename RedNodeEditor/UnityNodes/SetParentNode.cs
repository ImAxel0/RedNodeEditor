using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class SetParentNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }

    [XmlIgnore]
    public Transform NewParent { get; set; }

    public bool WorldPositionStays { get; set; }

    public SetParentNode()
    {
        Name = "SetParent";
        Description = "Sets the parent Transform of the passed transform\n" +
            "WorldPositionStays: if true, the parent-relative position, scale and rotation are modified such that the " +
            "object keeps the same world space position, rotation and scale as before.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(NewParent) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(WorldPositionStays) });
    }
}
