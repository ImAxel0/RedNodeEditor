using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class RigidbodySetKinematicNode : SonsNode
{
    [XmlIgnore]
    public Rigidbody Rigidbody { get; set; }
    public bool Value { get; set; }

    public RigidbodySetKinematicNode()
    {
        Name = "Rigidbody.SetKinematic";
        Description = "Controls whether physics affects the rigidbody.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
