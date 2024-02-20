using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class IsGameObjectActiveNode : SonsNode
{
    [IsArgOut]
    public bool IsActive {  get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var go = (GameObject)args[0];
        IsActive = go.activeSelf;
    }
}
