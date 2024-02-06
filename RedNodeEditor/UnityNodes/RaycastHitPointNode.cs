using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class RaycastHitPointNode : SonsNode
{
    public RaycastHitPointNode()
    {
        Name = "RaycastHit.Point";
        Description = "Gets the position of the collider hit by a Physics.Raycast";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(RaycastHit), ArgName = nameof(RaycastHit) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
