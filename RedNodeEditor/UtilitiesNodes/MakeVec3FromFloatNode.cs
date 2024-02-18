using System.Numerics;

namespace RedNodeEditor.UtilitiesNodes;

public class MakeVec3FromFloatNode : SonsNode
{
    public float Value { get; set; }

    public MakeVec3FromFloatNode()
    {
        Name = "MakeVec3FromFloat";
        Description = "Makes a vector3 from a float input where (x,y,z) are equals to the float value";
        NodeCategory = NodeCategories.Utilities;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
