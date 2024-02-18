using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace RedNodeEditor.UnityNodes;

public class TransformLeftNode : SonsNode
{
    public TransformLeftNode()
    {
        Name = "Transform.Left";
        Description = "Manipulate a GameObject’s position on the X axis of the transform in world space";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
