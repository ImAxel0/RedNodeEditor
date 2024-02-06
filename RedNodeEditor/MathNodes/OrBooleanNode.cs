namespace RedNodeEditor.MathNodes;

public class OrBooleanNode : SonsNode
{
    public OrBooleanNode()
    {
        Name = "OR Boolean (||)";
        Description = "Returns true if atleast one of the inputs is true";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
