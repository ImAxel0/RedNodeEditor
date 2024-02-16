using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class GetBoolFieldValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }

    public GetBoolFieldValueNode()
    {
        Name = "GetBoolFieldValue";
        Description = "Gets the field value of a boolean field contained in the passed component";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
