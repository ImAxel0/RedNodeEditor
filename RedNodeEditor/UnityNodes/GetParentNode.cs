using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class GetParentNode : SonsNode
{
    public GetParentNode()
    {
        Name = "GetParent";
        Description = "Gets the parent Transform of the passed transform";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Transform) });
    }
}
