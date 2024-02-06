using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class IsGameObjectActiveNode : SonsNode
{
    public IsGameObjectActiveNode()
    {
        Name = "IsGameObjectActive";
        Description = "Returns true if the passed GameObject is active, else returns false";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(GameObject), ArgName = nameof(GameObject) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
