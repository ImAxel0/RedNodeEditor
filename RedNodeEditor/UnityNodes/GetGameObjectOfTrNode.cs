using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class GetGameObjectOfTrNode : SonsNode
{
    public GetGameObjectOfTrNode()
    {
        Name = "GetGameObjectOfTr";
        Description = "Gets the GameObject of the passed Transform";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(GameObject) });
    }
}
