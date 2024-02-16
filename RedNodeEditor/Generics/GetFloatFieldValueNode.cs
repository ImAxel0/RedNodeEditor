using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class GetFloatFieldValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }

    public GetFloatFieldValueNode()
    {
        Name = "GetFloatFieldValue";
        Description = "Gets the field value of a float field contained in the passed component";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
