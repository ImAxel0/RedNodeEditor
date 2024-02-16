using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class RaycastHitTransformNode : SonsNode
{
    public RaycastHitTransformNode()
    {
        Name = "RaycastHit.Transform";
        Description = "Gets the Transform of the collider hit by a Physics.Raycast";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(RaycastHit), ArgName = nameof(RaycastHit) });
        ArgsOut.Add(new ArgOut { Type = typeof(Transform) });
    }
}
