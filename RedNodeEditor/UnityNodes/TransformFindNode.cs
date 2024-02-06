using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class TransformFindNode : SonsNode
{
    [XmlIgnore]
    public Transform Transform { get; set; }
    public string PathName { get; set; }

    public TransformFindNode()
    {
        Name = "Transform.Find";
        Description = "Finds and gets a child Transform of the passed Transform by the given name or path to it";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PathName) });
        ArgsOut.Add(new ArgOut { Type = typeof(Transform) });
    }
}
