using UnityEngine;

namespace RedNodeLoader.UnityNodes;

public class GetTagNode : SonsNode
{
    [IsArgOut]
    public string Tag {  get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var go = (GameObject)args[0];
        Tag = go.tag;
    }
}
