using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class GetBoolPropertyValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }

    public GetBoolPropertyValueNode()
    {
        Name = "GetBoolPropertyValue";
        Description = "Gets the property value of a boolean property contained in the passed component";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
