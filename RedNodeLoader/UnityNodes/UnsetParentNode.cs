using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class UnsetParentNode : SonsNode
{
    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var tr = (Transform)args[0];
        tr.SetParent(null);
    }
}
