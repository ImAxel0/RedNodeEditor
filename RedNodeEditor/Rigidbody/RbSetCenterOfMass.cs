using System.Xml.Serialization;
using System.Numerics;

namespace RedNodeEditor.UnityNodes.Rigidbody;

public class RbSetCenterOfMass : SonsNode
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public Vector3 Center { get; set; }

    public RbSetCenterOfMass()
    {
        Name = nameof(RbSetCenterOfMass);
        Description = "Sets the center of mass relative to the transform's origin.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Center) });
    }
}
