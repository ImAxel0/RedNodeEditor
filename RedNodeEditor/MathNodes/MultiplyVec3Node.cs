using IconFonts;
using System.Numerics;

namespace RedNodeEditor.MathNodes;

public class MultiplyVec3Node : SonsNode
{
    public Vector3 First { get; set; }
    public Vector3 Second { get; set; }

    public MultiplyVec3Node()
    {
        Name = $"MultiplyVec3 {FontAwesome6.Asterisk} {FontAwesome6.Asterisk} {FontAwesome6.Asterisk}";
        Description = "Multiplies two vector 3 and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
