using IconFonts;

namespace RedNodeEditor.MathNodes;

public class GreaterThanEqualNode : SonsNode
{
    public float First { get; set; }
    public float Second { get; set; }

    public GreaterThanEqualNode()
    {
        Name = $"GreaterThanEqual {FontAwesome6.GreaterThanEqual}";
        Description = "Returns true if first is greater or equal to second";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
