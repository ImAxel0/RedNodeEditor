using System.Numerics;

namespace RedNodeEditor.VariablesNodes;

public class Vector3SetNode : SonsNode
{
    public Vector3 ValueIn { get; set; }

    public Vector3SetNode()
    {
        Name = "Vector3Set";
        NodeType = NodeTypes.Variable;
        Description = "Sets the value of the Vector3 variable";

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(ValueIn) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
