using UnityEngine;

namespace RedNodeLoader.InputNodes;

public class GetKeyDownEnumNode : SonsNode
{
    public KeyCode EnumValue { get; set; }

    [IsArgOut]
    public bool WasPressed { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        WasPressed = Input.GetKeyDown((KeyCode)args[0]);
    }
}
