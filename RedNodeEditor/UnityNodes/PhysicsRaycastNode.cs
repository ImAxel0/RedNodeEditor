using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class PhysicsRaycastNode : SonsNode
{
    public Vector3 Origin { get; set; }
    public Vector3 Direction { get; set; }
    public float MaxDistance { get; set; } = Mathf.Infinity;

    public PhysicsRaycastNode() 
    {
        Name = "Physics.Raycast";
        Description = "Cast a ray from the given origin to the given direction and max distance.\n" +
            "Returns true if it encounters a collider and stores info about it in the RaycastHit output structure";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Origin) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Direction) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(MaxDistance) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(RaycastHit) });
    }
}
