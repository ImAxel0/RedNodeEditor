using Sons.Ai.Vail;

namespace RedNodeLoader.ActorsNodes;

public class GetActiveCountNode : SonsNode
{
    [IsArgOut]
    public int Count { get; set; }

    public override void Execute()
    {
        Count = VailActorManager.GetActiveCount();
    }
}
