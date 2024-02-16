using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class SetFloatPropertyValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }
    public float Value { get; set; }

    public SetFloatPropertyValueNode()
    {
        Name = "SetFloatPropertyValue";
        Description = "Sets the property value of a float property contained in the passed component. The property must have a SET accessor";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
