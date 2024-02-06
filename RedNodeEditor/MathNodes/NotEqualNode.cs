namespace RedNodeEditor.MathNodes;

public class NotEqualNode : SonsNode
{
    public float First { get; set; }
    public float Second { get; set; }

    public NotEqualNode()
    {
        Name = "NotEqual (!=)";
        Description = "Returns true if the two numeric values aren't the same";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
