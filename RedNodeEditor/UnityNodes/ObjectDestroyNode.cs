using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class ObjectDestroyNode : SonsNode
{
    public ObjectDestroyNode()
    {
        Name = "Object.Destroy";
        Description = "Destroyes the passed GameObject";
        NodeCategory = NodeCategories.Unity;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(GameObject), ArgName = nameof(GameObject) });
    }
}
