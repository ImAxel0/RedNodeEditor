using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.MathNodes;

public class Vector3DistanceNode : SonsNode
{
    public Vector3 A { get; set; }
    public Vector3 B { get; set; }

    public Vector3DistanceNode()
    {
        Name = "Vector3.Distance";
        Description = "Returns the distance between the two vectors A and B";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(A) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(B) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
