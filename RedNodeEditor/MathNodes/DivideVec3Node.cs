using System.Numerics;

namespace RedNodeEditor.MathNodes;

public class DivideVec3Node : SonsNode
{
    public Vector3 First { get; set; }
    public Vector3 Second { get; set; }

    public DivideVec3Node()
    {
        Name = "DivideVec3 (/) (/) (/)";
        Description = "Divides first vector 3 by secoond and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
