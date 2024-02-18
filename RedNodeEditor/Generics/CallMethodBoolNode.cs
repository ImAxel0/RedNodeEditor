using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class CallMethodBoolNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }

    public string MethodName { get; set; }
    public bool Value { get; set; }

    public CallMethodBoolNode()
    {
        Name = "CallMethod(Bool)";
        Description = "Calls a method of the passed component which takes one boolean parameter";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(MethodName) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
