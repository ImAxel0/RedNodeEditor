using SonsSdk;
using System.Xml.Serialization;
using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class GetComponentInChildrenNode : SonsNode
{
    [XmlIgnore]
    public GameObject GameObject { get; set; }
    public string ComponentName { get; set; }

    [XmlIgnore]
    [IsArgOut]
    public Component Component { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var go = (GameObject)args[0];

        GetAllChidren(go.transform, Children);
        foreach (var child in Children)
        {
            var cmp = child.GetComponent((string)args[1]);

            if (cmp)
            {
                Component = cmp;
                break;
            }
        }
        Children.Clear();
    }

    List<Transform> Children = new();
    private void GetAllChidren(Transform parent, List<Transform> list)
    {
        foreach (Transform child in parent.GetChildren())
        {
            list.Add(child.transform);
            GetAllChidren(child, list);
        }
    }
}