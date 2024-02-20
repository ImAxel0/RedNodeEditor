using System.Numerics;

namespace RedNodeLoader.UtilitiesNodes;

public class Vec3ToStringNode : SonsNode
{
    [IsArgOut]
    public string Converted { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Converted = Convert.ToString((Vector3)args[0]);
    }
}
