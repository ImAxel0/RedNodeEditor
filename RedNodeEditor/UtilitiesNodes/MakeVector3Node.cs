using System.Numerics;

namespace RedNodeEditor.UtilitiesNodes;

public class MakeVector3Node : SonsNode
{
    public MakeVector3Node()
    {
        Name = "MakeVector3";
        Description = "Makes a vector3 from three float input";
        NodeCategory = NodeCategories.Utilities;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = "x" });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = "y" });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = "z" });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
