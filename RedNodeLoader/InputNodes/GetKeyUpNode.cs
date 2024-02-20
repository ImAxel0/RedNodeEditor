using UnityEngine;

namespace RedNodeLoader.InputNodes;

public class GetKeyUpNode : SonsNode
{
    public string KeyName { get; set; }

    [IsArgOut]
    public bool WasReleased { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        WasReleased = Input.GetKeyUp((string)args[0]);
    }
}
