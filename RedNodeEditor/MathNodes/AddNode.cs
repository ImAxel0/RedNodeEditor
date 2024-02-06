namespace RedNodeEditor.MathNodes;

public class AddNode : SonsNode
{
    public float First { get; set; }
    public float Second { get; set; }

    public AddNode() 
    {
        Name = "Add (+)";
        Description = "Sum two numeric values and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
