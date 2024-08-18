using System.Xml.Serialization;

namespace RedNodeEditor.UnityNodes.Rigidbody;

public class RbSetAngularDrag : SonsNode
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public float Drag { get; set; }

    public RbSetAngularDrag()
    {
        Name = nameof(RbSetAngularDrag);
        Description = "Sets the angular drag of the object.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Drag) });
    }
}
