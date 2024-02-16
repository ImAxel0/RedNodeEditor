using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class SetObjectPropertyValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }
    public object Value { get; set; }

    public SetObjectPropertyValueNode()
    {
        Name = "SetObjectPropertyValue";
        Description = "Sets the property value of an object property contained in the passed component. The property must have a SET accessor";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsIn.Add(new ArgIn { Type = typeof(object), ArgName = nameof(Value) });
    }
}
