using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class GetRigidbodyNode : SonsNode
{
    public GetRigidbodyNode()
    {
        Name = "GetRigidbody";
        Description = "Gets the rigidbody component of the passed transform if it has one, else null";
        NodeCategory = NodeCategories.Unity;

        ArgsIn.Add(new ArgIn { Type = typeof(Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Rigidbody) });
    }
}
