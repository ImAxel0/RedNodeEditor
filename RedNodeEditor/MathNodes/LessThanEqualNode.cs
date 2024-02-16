using IconFonts;

namespace RedNodeEditor.MathNodes;

public class LessThanEqualNode : SonsNode
{
    public float First { get; set; }
    public float Second { get; set; }

    public LessThanEqualNode()
    {
        Name = $"LessThanEqual {FontAwesome6.LessThanEqual}";
        Description = "Returns true if first is less or equal to second";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
