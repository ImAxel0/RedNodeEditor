using UnityEngine;

namespace RedNodeEditor.PlayerNodes;

public class LocalPlayerRigidbodyNode : SonsNode
{
    public LocalPlayerRigidbodyNode()
    {
        Name = "LocalPlayerRigidbody";
        Description = "Gets the LocalPlayer rigidbody";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(Rigidbody) });
    }
}
