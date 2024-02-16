using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class RaycastHitDistanceNode : SonsNode
{
    public RaycastHitDistanceNode()
    {
        Name = "RaycastHit.Distance";
        Description = "Gets the distance of the collider hit by a Physics.Raycast from the ray origin";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(RaycastHit), ArgName = nameof(RaycastHit) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
