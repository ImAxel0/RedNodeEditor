using Sons.Ai.Vail;

namespace RedNodeLoader.ActorsNodes;

public class KillEnemiesNode : SonsNode
{
    public override void Execute()
    {
        VailActorManager.GetActiveActors().ToList().ForEach(actor =>
        {
            if (actor.ClassId == VailActorClassId.Cannibal || actor.ClassId == VailActorClassId.Creepy)
            {
                actor.ForceDeath();
            }
        });
    }
}
