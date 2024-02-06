using UnityEngine;

namespace RedNodeEditor.PlayerNodes;

public class GetCameraTransformNode : SonsNode
{
    public GetCameraTransformNode()
    {
        Name = "GetCameraTransform";
        Description = "Returns player camera Transform";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(Transform) });
    }
}
