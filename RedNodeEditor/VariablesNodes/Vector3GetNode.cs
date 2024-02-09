using System.Numerics;

namespace RedNodeEditor.VariablesNodes;

public class Vector3GetNode : SonsNode
{
    public Vector3GetNode()
    {
        Name = "Vector3Get";
        NodeType = NodeTypes.Variable;
        Description = "Gets the value of the Vector3 variable";

        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
