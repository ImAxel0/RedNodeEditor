using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class CallMethodFloatNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }

    public string MethodName { get; set; }
    public float Value { get; set; }

    public CallMethodFloatNode()
    {
        Name = "CallMethod(Float)";
        Description = "Calls a method of the passed component which takes one float parameter";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(MethodName) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
