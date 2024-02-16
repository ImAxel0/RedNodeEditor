using IconFonts;

namespace RedNodeEditor.MathNodes;

public class IsNullNode : SonsNode
{
    public IsNullNode()
    {
        Name = $"IsNull {FontAwesome6.Question}";
        Description = "Returns true if passed object is null, else return false";
        NodeCategory = NodeCategories.Math;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(object) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
