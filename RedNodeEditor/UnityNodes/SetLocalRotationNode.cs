using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class SetLocalRotationNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }

    public Vector3 Rotation { get; set; }

    public SetLocalRotationNode()
    {
        Name = "SetLocalRotation";
        Description = "Sets the local rotation of the passed transform";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Rotation) });
    }
}
