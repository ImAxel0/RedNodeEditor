using Sons.Ai.Vail;
using System.Numerics;

namespace RedNodeLoader.ActorsNodes;

public class DismemberActorsInRadiusNode : SonsNode
{
    public Vector3 Center { get; set; }
    public float Radius { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        var center = (Vector3)args[0];
        VailActorManager._instance.DismemberActorsInRadius(new UnityEngine.Vector3(center.X, center.Y, center.Z), (float)args[1]);
    }
}
