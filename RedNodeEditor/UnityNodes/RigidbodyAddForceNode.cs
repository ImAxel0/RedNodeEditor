using Newtonsoft.Json;
using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class RigidbodyAddForceNode : SonsNode
{
    [XmlIgnore]
    public Rigidbody Rigidbody { get; set; }
    public Vector3 Direction { get; set; }

    [IgnoreProperty]
    public ForceMode EnumValue { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> ForceModes { get; set; } = new();

    public RigidbodyAddForceNode()
    {
        Name = "Rigidbody.AddForce";
        Description = "Adds a force to the passed rigidbody in the given direction and type";
        NodeCategory = NodeCategories.Unity;

        foreach (var forceMode in Enum.GetValues(typeof(ForceMode)))
            ForceModes.Add((ForceMode)forceMode);

        ArgsIn.Add(new ArgIn { Type = typeof(Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Direction) });
        ArgsIn.Add(new ArgIn { Type = typeof(ForceMode), ArgName = nameof(ForceMode) });
    }
}
