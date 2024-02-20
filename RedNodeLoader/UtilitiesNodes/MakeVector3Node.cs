using System.Numerics;

namespace RedNodeLoader.UtilitiesNodes;

public class MakeVector3Node : SonsNode
{
    [IsArgOut]
    public Vector3 xyz { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        xyz = new Vector3((float)args[0], (float)args[1], (float)args[2]);
    }
}
