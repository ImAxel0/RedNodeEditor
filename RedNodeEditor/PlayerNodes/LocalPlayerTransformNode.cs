using UnityEngine;

namespace RedNodeEditor.PlayerNodes;

public class LocalPlayerTransformNode : SonsNode
{
    public LocalPlayerTransformNode()
    {
        Name = "LocalPlayerTransform";
        Description = "Gets the LocalPlayer transform";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(Transform) });
    }
}
