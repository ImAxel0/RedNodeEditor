namespace RedNodeEditor.MathNodes;

public class IsNotNullNode : SonsNode
{
    public IsNotNullNode()
    {
        Name = "IsNotNullNode (!?)";
        Description = "Returns true if passed object is not null, else return false";
        NodeCategory = NodeCategories.Math;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(object) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
