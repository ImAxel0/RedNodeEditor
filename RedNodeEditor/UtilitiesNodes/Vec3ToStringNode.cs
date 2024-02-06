using System.Numerics;

namespace RedNodeEditor.UtilitiesNodes;

public class Vec3ToStringNode : SonsNode
{
    public Vec3ToStringNode()
    {
        Name = "Vec3ToString";
        Description = "Convert vector3 input to string output";
        NodeCategory = NodeCategories.Utilities;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3) });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
