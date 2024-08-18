using System.Numerics;
using System.Xml.Serialization;

namespace RedNodeEditor.UnityNodes.Rigidbody;

public class RbMove : SonsNode
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public Vector3 Pos { get; set; }
    public Vector3 Rot { get; set; }

    public RbMove()
    {
        Name = nameof(RbMove);
        Description = "Moves the Rigidbody to position and rotates the Rigidbody to rotation.";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Pos) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Rot) });
    }
}
