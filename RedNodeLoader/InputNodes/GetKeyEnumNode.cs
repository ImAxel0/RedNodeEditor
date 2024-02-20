using UnityEngine;

namespace RedNodeLoader.InputNodes;

public class GetKeyEnumNode : SonsNode
{
    public KeyCode EnumValue { get; set; }

    [IsArgOut]
    public bool WasPressed { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        WasPressed = Input.GetKey((KeyCode)args[0]);
    }
}
