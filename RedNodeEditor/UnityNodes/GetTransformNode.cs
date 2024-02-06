using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class GetTransformNode : SonsNode
{
    public GetTransformNode()
    {
        Name = "GetTransform";
        Description = "Gets the Transform of the passed GameObject";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(GameObject), ArgName = nameof(GameObject) });
        ArgsOut.Add(new ArgOut { Type = typeof(Transform) });
    }
}
