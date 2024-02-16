using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class SetFloatFieldValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }
    public float Value { get; set; }

    public SetFloatFieldValueNode()
    {
        Name = "SetFloatFieldValueNode";
        Description = "Sets the field value of a float field contained in the passed component";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
