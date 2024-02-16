using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeEditor.Generics;

public class CallMethodNode : SonsNode
{
    [XmlIgnore]
    public Component Component { get; set; }

    public string MethodName { get; set; }

    public CallMethodNode()
    {
        Name = "CallMethod";
        Description = "Calls a method of the passed component which has no parameters";
        NodeCategory = NodeCategories.Generics;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(MethodName) });
    }
}
