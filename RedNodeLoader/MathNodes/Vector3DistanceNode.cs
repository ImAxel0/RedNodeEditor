using Vector3 = System.Numerics.Vector3;

namespace RedNodeLoader.MathNodes;

public class Vector3DistanceNode : SonsNode
{
    public Vector3 A { get; set; }
    public Vector3 B { get; set; }

    [IsArgOut]
    public float Distance { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var a = (Vector3)args[0];
        var b = (Vector3)args[1];
        Distance = UnityEngine.Vector3.Distance(new UnityEngine.Vector3(a.X, a.Y, a.Z), new UnityEngine.Vector3(b.X, b.Y, b.Z));
    }
}
