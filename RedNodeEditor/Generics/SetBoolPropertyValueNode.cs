using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class SetBoolPropertyValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }
    public bool Value { get; set; }

    public SetBoolPropertyValueNode()
    {
        Name = "SetBoolPropertyValue";
        Description = "Sets the property value of a boolean property contained in the passed component. The property must have a SET accessor";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
