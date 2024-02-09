namespace RedNodeEditor.MathNodes;

public class FlipBoolNode : SonsNode
{
    public FlipBoolNode()
    {
        Name = "FlipBool (!)";
        Description = "Flips the passed boolean value";
        NodeCategory = NodeCategories.Math;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
