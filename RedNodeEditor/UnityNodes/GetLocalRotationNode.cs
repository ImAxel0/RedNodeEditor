using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class GetLocalRotationNode : SonsNode
{
    public GetLocalRotationNode()
    {
        Name = "GetLocalRotation";
        Description = "Gets the local rotation of the passed Transform";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
