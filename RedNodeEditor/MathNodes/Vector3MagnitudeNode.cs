using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.MathNodes;

public class Vector3MagnitudeNode : SonsNode
{
    public Vector3 Vector3 { get; set; }

    public Vector3MagnitudeNode()
    {
        Name = "Vector3.Magnitude";
        Description = "Returns the length of this vector. The length of the vector is square root of (x*x+y*y+z*z)";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Vector3) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
