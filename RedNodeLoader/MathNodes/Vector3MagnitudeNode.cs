using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.MathNodes;

public class Vector3MagnitudeNode : SonsNode
{
    public Vector3 Vector3 { get; set; }

    [IsArgOut]
    public float Magnitude { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var vec3 = (Vector3)args[0];
        Magnitude = new UnityEngine.Vector3(vec3.X, vec3.Y, vec3.Z).magnitude;
    }
}
