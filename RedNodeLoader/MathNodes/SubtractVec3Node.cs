using System.Numerics;

namespace RedNodeLoader.MathNodes;

public class SubtractVec3Node : SonsNode
{
    public Vector3 First { get; set; }
    public Vector3 Second { get; set; }

    [IsArgOut]
    public Vector3 Result { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Result = (Vector3)args[0] - (Vector3)args[1];
    }
}
