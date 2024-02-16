using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class GetFloatPropertyValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }

    public GetFloatPropertyValueNode()
    {
        Name = "GetFloatPropertyValue";
        Description = "Gets the property value of a float property contained in the passed component";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
