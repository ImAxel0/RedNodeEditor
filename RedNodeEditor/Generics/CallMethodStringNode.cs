using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class CallMethodStringNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }

    public string MethodName { get; set; }
    public string Value { get; set; }

    public CallMethodStringNode()
    {
        Name = "CallMethod(String)";
        Description = "Calls a method of the passed component which takes one string parameter";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(MethodName) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Value) });
    }
}
