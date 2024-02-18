using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class TransformBackwardNode : SonsNode
{
    public TransformBackwardNode()
    {
        Name = "Transform.Backward";
        Description = "Manipulate a GameObject’s position on the Z axis of the transform in world space";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
