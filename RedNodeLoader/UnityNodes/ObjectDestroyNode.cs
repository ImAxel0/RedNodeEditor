using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class ObjectDestroyNode : SonsNode
{
    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var go = (GameObject)args[0];
        UnityEngine.Object.Destroy(go);
    }
}
