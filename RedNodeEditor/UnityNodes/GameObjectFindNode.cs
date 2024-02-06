using UnityEngine;

namespace RedNodeEditor.UnityNodes;

public class GameObjectFindNode : SonsNode
{
    public string name { get; set; }

    public GameObjectFindNode()
    {
        Name = "GameObject.Find";
        Description = "Find a GameObject by name (resources intensive if called every frame)";
        NodeCategory = NodeCategories.Unity;
        
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(name) });
        ArgsOut.Add(new ArgOut { Type = typeof(GameObject) });
    }
}
