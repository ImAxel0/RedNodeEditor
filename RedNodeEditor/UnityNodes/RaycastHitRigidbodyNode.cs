using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class RaycastHitRigidbodyNode : SonsNode
{
    public RaycastHitRigidbodyNode()
    {
        Name = "RaycastHit.Rigidbody";
        Description = "Gets the Rigidbody of the collider hit by a Physics.Raycast";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(RaycastHit), ArgName = nameof(RaycastHit) });
        ArgsOut.Add(new ArgOut { Type = typeof(Rigidbody) });
    }
}
