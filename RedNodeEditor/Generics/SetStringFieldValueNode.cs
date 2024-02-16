using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class SetStringFieldValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }
    public string Value { get; set; }

    public SetStringFieldValueNode()
    {
        Name = "SetStringFieldValue";
        Description = "Sets the field value of a string field contained in the passed component";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Value) });
    }
}
