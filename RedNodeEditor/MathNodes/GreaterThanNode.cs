using IconFonts;

namespace RedNodeEditor.MathNodes;

public class GreaterThanNode : SonsNode
{
    public float First { get; set; }
    public float Second { get; set; }

    public GreaterThanNode()
    {
        Name = $"GreaterThan {FontAwesome6.GreaterThan}";
        Description = "Returns true if first is greater than second";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
