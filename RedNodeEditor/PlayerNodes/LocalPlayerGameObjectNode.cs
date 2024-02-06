using UnityEngine;

namespace RedNodeEditor.PlayerNodes;

public class LocalPlayerGameObjectNode : SonsNode
{
    public LocalPlayerGameObjectNode()
    {
        Name = "LocalPlayerGameObject";
        Description = "Gets the LocalPlayer gameobject";
        NodeCategory = NodeCategories.Player;

        ArgsOut.Add(new ArgOut { Type = typeof(GameObject) });
    }
}
