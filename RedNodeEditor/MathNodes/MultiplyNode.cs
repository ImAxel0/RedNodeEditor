using IconFonts;

namespace RedNodeEditor.MathNodes;

public class MultiplyNode : SonsNode
{
    public float First { get; set; }
    public float Second { get; set; }

    public MultiplyNode()
    {
        Name = $"Multiply {FontAwesome6.Asterisk}";
        Description = "Multiplies two numeric values and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
