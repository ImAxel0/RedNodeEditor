using IconFonts;

namespace RedNodeEditor.MathNodes;

public class EqualIntNode : SonsNode
{
    public int First { get; set; }
    public int Second { get; set; }

    public EqualIntNode()
    {
        Name = $"Equal (int) {FontAwesome6.Equals}";
        Description = "Returns true if the two numeric values are the same";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
