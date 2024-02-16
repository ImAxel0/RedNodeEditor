using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class GetIntPropertyValueNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }

    public GetIntPropertyValueNode()
    {
        Name = "GetIntPropertyValue";
        Description = "Gets the property value of an integer property contained in the passed component";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
