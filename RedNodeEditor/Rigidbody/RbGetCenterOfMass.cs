using System.Numerics;

namespace RedNodeEditor.UnityNodes.Rigidbody;

public class RbGetCenterOfMass : SonsNode
{
    public RbGetCenterOfMass()
    {
        Name = nameof(RbGetCenterOfMass);
        Description = "Returns the center of mass relative to the transform's origin.";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
