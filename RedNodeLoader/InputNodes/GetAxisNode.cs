using UnityEngine;

namespace RedNodeLoader.InputNodes;

public class GetAxisNode : SonsNode
{
    public string AxisName { get; set; }

    [IsArgOut]
    public float AxisValue { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        AxisValue = Input.GetAxis((string)args[0]);
    }
}
