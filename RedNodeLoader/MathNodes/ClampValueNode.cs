using UnityEngine;

namespace RedNodeLoader.MathNodes;

public class ClampValueNode : SonsNode
{
    public float Value { get; set; }
    public float Min { get; set; }
    public float Max { get; set; }

    [IsArgOut]
    public float Result { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Result = Mathf.Clamp((float)args[0], (float)args[1], (float)args[2]);
    }
}
