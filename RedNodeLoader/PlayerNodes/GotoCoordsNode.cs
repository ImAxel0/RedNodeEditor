using System.Numerics;
using TheForest.Utils;

namespace RedNodeLoader.PlayerNodes;

public class GotoCoordsNode : SonsNode
{
    public Vector3 xyz { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        Vector3 v = (Vector3)args[0];
        LocalPlayer._instance.Goto(new UnityEngine.Vector3(v.X, v.Y, v.Z));
    }
}
