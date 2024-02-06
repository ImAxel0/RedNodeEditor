using System.Numerics;

namespace RedNodeEditor.UtilitiesNodes;

public class BreakVector3Node : SonsNode
{
    public BreakVector3Node()
    {
        Name = "BreakVector3";
        Description = "Breaks a vector3 input to (x, y, z) float values";
        NodeCategory = NodeCategories.Utilities;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = "xyz" });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
