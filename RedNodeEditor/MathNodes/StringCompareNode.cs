namespace RedNodeEditor.MathNodes;

public class StringCompareNode : SonsNode
{
    public string First { get; set; }
    public string Second { get; set; }

    public StringCompareNode()
    {
        Name = "StringCompare";
        Description = "Returns true if the two strings are the same (case sensitive)";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
