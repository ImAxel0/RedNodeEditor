using UnityEngine;

namespace RedNodeLoader.InputNodes;

public class GetKeyNode : SonsNode
{
    public string KeyName { get; set; }

    [IsArgOut]
    public bool WasPressed { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        WasPressed = Input.GetKey((string)args[0]);
    }
}
