using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class LookAtNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }

    public Vector3 LookDirection { get; set; }

    public LookAtNode()
    {
        Name = "LookAt";
        Description = "Makes the Transform looks in a direction";
        NodeCategory = NodeCategories.Unity;
        
        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(LookDirection) });
    }
}
