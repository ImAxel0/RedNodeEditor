using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedNodeEditor.VariablesNodes;

public class ObjectGetNode : SonsNode
{
    public ObjectGetNode()
    {
        Name = "ObjectGet";
        NodeType = NodeTypes.Variable;
        Description = "Gets the value of the object variable";

        ArgsOut.Add(new ArgOut { Type = typeof(object) });
    }
}
