using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class GetIntFieldValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }

    public GetIntFieldValueNode()
    {
        Name = "GetIntFieldValue";
        Description = "Gets the field value of an integer field contained in the passed component";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
