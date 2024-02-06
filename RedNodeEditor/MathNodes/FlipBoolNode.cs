namespace RedNodeEditor.MathNodes;

public class FlipBoolNode : SonsNode
{
    public FlipBoolNode()
    {
        Name = "FlipBool (!)";
        Description = "Flips the passed boolean value";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
