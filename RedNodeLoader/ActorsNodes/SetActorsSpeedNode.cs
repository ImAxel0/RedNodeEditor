using Sons.Ai.Vail;

namespace RedNodeLoader.ActorsNodes;

public class SetActorsSpeedNode : SonsNode
{
    public float Speed { get; set; }

    public override void Execute()
    {
        List<object> args = RedNodeLoader.GetArgumentsOf(this);
        VailActorManager.DebugSetAnimSpeed((float)args[0]);
    }
}
