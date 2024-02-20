using UnityEngine;

namespace RedNodeLoader.InputNodes;

public class GetAxisRawNode : SonsNode
{
    public string AxisName { get; set; }

    [IsArgOut]
    public float AxisValue { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        AxisValue = Input.GetAxisRaw((string)args[0]);
    }
}
