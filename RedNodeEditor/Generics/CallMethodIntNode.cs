using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class CallMethodIntNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }

    public string MethodName { get; set; }
    public int Value { get; set; }

    public CallMethodIntNode()
    {
        Name = "CallMethod(Int)";
        Description = "Calls a method of the passed component which takes one integer parameter";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(MethodName) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Value) });
    }
}
