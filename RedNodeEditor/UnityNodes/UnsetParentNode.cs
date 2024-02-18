using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class UnsetParentNode : SonsNode
{
    public UnsetParentNode()
    {
        Name = "UnsetParent";
        Description = "Detaches the parent Transform from the passed transform";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
    }
}
