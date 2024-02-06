namespace RedNodeEditor.MathNodes;

public class LessThanNode : SonsNode
{
    public float First { get; set; }
    public float Second { get; set; }

    public LessThanNode()
    {
        Name = "LessThan (<)";
        Description = "Returns true if first is less than second";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
