using System.Numerics;

namespace RedNodeEditor.MathNodes;

public class AddVec3Node : SonsNode
{
    public Vector3 First { get; set; }
    public Vector3 Second { get; set; }

    public AddVec3Node()
    {
        Name = "AddVec3 (+) (+) (+)";
        Description = "Sum two vector 3 and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
