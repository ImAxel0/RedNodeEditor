using Sons.Ai.Vail;

namespace RedNodeLoader.ActorsNodes;

public class KillAnimalsNode : SonsNode
{
    public override void Execute()
    {
        VailActorManager.GetActiveActors().ToList().ForEach(actor =>
        {
            if (actor.ClassId == VailActorClassId.Animal)
            {
                actor.ForceDeath();
            }
        });
    }
}
