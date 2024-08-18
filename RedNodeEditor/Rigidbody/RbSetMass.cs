using System.Xml.Serialization;

namespace RedNodeEditor.UnityNodes.Rigidbody;

public class RbSetMass : SonsNode
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public float Mass { get; set; }

    public RbSetMass()
    {
        Name = nameof(RbSetMass);
        Description = "Sets the mass of the rigidbody.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Mass) });
    }
}
