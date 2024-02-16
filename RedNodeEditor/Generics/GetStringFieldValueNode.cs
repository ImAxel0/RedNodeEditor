using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class GetStringFieldValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }

    public GetStringFieldValueNode()
    {
        Name = "GetStringFieldValue";
        Description = "Gets the field value of a string field contained in the passed component";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
