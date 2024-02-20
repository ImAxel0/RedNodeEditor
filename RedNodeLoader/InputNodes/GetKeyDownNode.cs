using UnityEngine;

namespace RedNodeLoader.InputNodes;

public class GetKeyDownNode : SonsNode
{
    public string KeyName { get; set; }

    [IsArgOut]
    public bool WasPressed { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        WasPressed = Input.GetKeyDown((string)args[0]);        
    }
}
