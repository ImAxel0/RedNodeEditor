using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class GetRootTransformNode : SonsNode
{
    public GetRootTransformNode()
    {
        Name = "GetRootTransform";
        Description = "Gets the root Transform of the passed Transform (the Transform at the top of the hierarchy)";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Transform) });
    }
}
