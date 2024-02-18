using Newtonsoft.Json;
using System.Xml.Serialization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class TransformRotateNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }

    public Vector3 Rotation { get; set; }

    [IgnoreProperty]
    public Space EnumValue { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> SpaceEnums { get; set; } = new();

    public TransformRotateNode()
    {
        Name = "Transform.Rotate";
        Description = "Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x degrees around the x-axis, and eulerAngles.y degrees around the y-axis";
        NodeCategory = NodeCategories.Unity;

        foreach (var key in Enum.GetValues(typeof(Space)))
            SpaceEnums.Add((Space)key);

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Rotation) });
        ArgsIn.Add(new ArgIn { Type = typeof(Space), ArgName = nameof(Space) });
    }
}
