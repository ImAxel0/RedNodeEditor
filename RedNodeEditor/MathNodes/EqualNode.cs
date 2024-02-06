namespace RedNodeEditor.MathNodes;

public class EqualNode : SonsNode
{
    public float First { get; set; }
    public float Second { get; set; }

    public EqualNode()
    {
        Name = "Equal (==)";
        Description = "Returns true if the two numeric values are the same";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
