using System.Numerics;

namespace RedNodeLoader.UtilitiesNodes;

public class BreakVector3Node : SonsNode
{
    [IsArgOut]
    public float X { get; set; }
    [IsArgOut]
    public float Y { get; set; }
    [IsArgOut]
    public float Z { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var vec3 = (Vector3)args[0];
        X = vec3.X; Y = vec3.Y; Z = vec3.Z;
    }
}
